using System.IO;
using UnityEditor;
using UnityEditor.Android;
using UnityEditor.Build;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using AvatarWorld.Runtime;

namespace AvatarWorld.EditorTools
{
    /// <summary>Preparacao do projeto em batch: unity run ... -- -executeMethod AvatarWorld.EditorTools.ProjectSetup.CreateHomeScene</summary>
    public static class ProjectSetup
    {
        const string HomeScenePath = "Assets/Scenes/Home.unity";
        // Pacote proprio: nunca o do jogo original (com.pazugames.avatarworld).
        const string AppId = "com.c1c3ru.avatarworldoffline";

        public static void CreateHomeScene()
        {
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            var camGo = new GameObject("Main Camera", typeof(Camera), typeof(AudioListener));
            camGo.tag = "MainCamera";
            var cam = camGo.GetComponent<Camera>();
            cam.clearFlags = CameraClearFlags.SolidColor;
            cam.backgroundColor = Color.black;
            cam.orthographic = true;

            new GameObject("Bootstrap", typeof(HomeBootstrap));

            Directory.CreateDirectory("Assets/Scenes");
            EditorSceneManager.SaveScene(scene, HomeScenePath);
            EditorBuildSettings.scenes = new[] { new EditorBuildSettingsScene(HomeScenePath, true) };
            Debug.Log("ProjectSetup: cena criada em " + HomeScenePath);
        }

        // Modulos instalados via "unity install-modules" apos o Editor ja existir: a deteccao
        // batch de "Installed with Unity" falha (modules.asset nao e re-escrito). Aponta direto
        // para os caminhos reais dentro do proprio Editor.
        static void ConfigureAndroidExternalTools()
        {
            // applicationPath is ".../<version>/Editor/Unity"; GetDirectoryName drops the executable, not any
            // "/Unity" substring elsewhere in the install path (e.g. a ~/Unity Hub root).
            string editorDir = Path.GetDirectoryName(EditorApplication.applicationPath);
            string playerRoot = editorDir + "/Data/PlaybackEngines/AndroidPlayer";
            AndroidExternalToolsSettings.sdkRootPath = playerRoot + "/SDK";
            AndroidExternalToolsSettings.ndkRootPath = playerRoot + "/NDK";
            AndroidExternalToolsSettings.jdkRootPath = playerRoot + "/OpenJDK";
            Debug.Log("ProjectSetup: Android external tools -> " + playerRoot);
        }

        /// <summary>
        /// O projeto nunca importou o TMP Essential Resources (TMP Settings.asset + fonte padrao):
        /// so existe o .unitypackage dentro de Library/PackageCache. Sem isso, criar
        /// TextMeshProUGUI em runtime lanca NullReferenceException (visto na Home: ~dezenas de
        /// excecoes ao montar os 9 nos de texto). unity run ... -executeMethod
        /// AvatarWorld.EditorTools.ProjectSetup.ImportTmpEssentials
        /// </summary>
        public static void ImportTmpEssentials()
        {
            var matches = Directory.GetFiles("Library/PackageCache", "TMP Essential Resources.unitypackage", SearchOption.AllDirectories);
            if (matches.Length == 0)
            {
                Debug.LogError("ProjectSetup: TMP Essential Resources.unitypackage nao encontrado em Library/PackageCache");
                EditorApplication.Exit(1);
                return;
            }
            AssetDatabase.ImportPackage(matches[0], false);
            Debug.Log("ProjectSetup: importado " + matches[0]);
        }

        public static void ConfigureAndroid()
        {
            ConfigureAndroidExternalTools();
            PlayerSettings.companyName = "c1c3ru";
            PlayerSettings.productName = "Avatar World (offline)";
            PlayerSettings.SetApplicationIdentifier(NamedBuildTarget.Android, AppId);
            PlayerSettings.SetScriptingBackend(NamedBuildTarget.Android, ScriptingImplementation.IL2CPP);
            PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64;
            PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel24;
            // Original (AndroidManifest.xml, confirmado via REA): UnityPlayerActivity usa
            // android:screenOrientation="userLandscape" (paisagem, nas duas direcoes, sem retrato).
            // A HomeSlice foi exportada com coordenadas pensadas pra paisagem; em retrato o layout
            // aparece "empilhado" porque o CanvasScaler usa a proporcao errada da tela.
            PlayerSettings.defaultInterfaceOrientation = UIOrientation.AutoRotation;
            PlayerSettings.allowedAutorotateToLandscapeLeft = true;
            PlayerSettings.allowedAutorotateToLandscapeRight = true;
            PlayerSettings.allowedAutorotateToPortrait = false;
            PlayerSettings.allowedAutorotateToPortraitUpsideDown = false;

            string iconPath = "Assets/Icon/app_icon.png";
            var iconTex = AssetDatabase.LoadAssetAtPath<Texture2D>(iconPath);
            if (iconTex != null)
                PlayerSettings.SetIconsForTargetGroup(BuildTargetGroup.Android, new[] { iconTex }, IconKind.Application);
            else
                Debug.LogWarning("ProjectSetup: " + iconPath + " nao encontrado, mantendo icone padrao do Unity");
            AssetDatabase.SaveAssets();
            Debug.Log("ProjectSetup: Android configurado (" + AppId + ", IL2CPP, ARM64, minSdk 24)");
        }

        public static void BuildAndroidDevelopment()
        {
            ConfigureAndroid();
            Directory.CreateDirectory("Builds");
            var report = BuildPipeline.BuildPlayer(new BuildPlayerOptions
            {
                scenes = new[] { HomeScenePath },
                locationPathName = "Builds/AvatarWorldOffline-dev.apk",
                target = BuildTarget.Android,
                options = BuildOptions.Development,
            });
            Debug.Log("ProjectSetup: build " + report.summary.result + " (" + report.summary.totalSize + " bytes)");
            if (report.summary.result != UnityEditor.Build.Reporting.BuildResult.Succeeded) EditorApplication.Exit(1);
        }
    }
}
