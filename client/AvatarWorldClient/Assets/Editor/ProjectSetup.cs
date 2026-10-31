using System.IO;
using UnityEditor;
using UnityEditor.Android;
using UnityEditor.Build;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;
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

        const string AvatarValidationScenePath = "Assets/Scenes/AvatarValidation.unity";

        /// <summary>
        /// Cena minima e isolada so pra provar o Ciclo 1 (docs/AVATAR_GAMEPLAY_PLAN.md) no Android de
        /// verdade: nada de Home/HomeBootstrap aqui de proposito, ainda e so a validacao do renderer,
        /// o acesso pela Home e um ciclo posterior (4).
        /// </summary>
        public static void CreateAvatarValidationScene()
        {
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            new GameObject("AvatarGpuRuntime", typeof(AvatarGpuRuntime));
            Directory.CreateDirectory("Assets/Scenes");
            EditorSceneManager.SaveScene(scene, AvatarValidationScenePath);
            Debug.Log("ProjectSetup: cena criada em " + AvatarValidationScenePath);
        }

        /// <summary>
        /// Shaders so referenciados por Shader.Find() em runtime (nunca por um Material-asset salvo)
        /// sao cortados do build pelo stripper - precisam estar na lista "Always Included Shaders"
        /// de Graphics Settings. AvatarGpuRuntime cria os Materials do avatar 100% em runtime.
        /// </summary>
        static void EnsureShaderAlwaysIncluded(string shaderName)
        {
            var shader = Shader.Find(shaderName);
            if (shader == null) { Debug.LogError("EnsureShaderAlwaysIncluded: shader nao encontrado " + shaderName); return; }

            var graphicsSettingsObj = AssetDatabase.LoadAssetAtPath<GraphicsSettings>("ProjectSettings/GraphicsSettings.asset");
            var serialized = new SerializedObject(graphicsSettingsObj);
            var list = serialized.FindProperty("m_AlwaysIncludedShaders");
            for (int i = 0; i < list.arraySize; i++)
                if (list.GetArrayElementAtIndex(i).objectReferenceValue == shader) { return; }

            list.InsertArrayElementAtIndex(list.arraySize);
            list.GetArrayElementAtIndex(list.arraySize - 1).objectReferenceValue = shader;
            serialized.ApplyModifiedProperties();
            Debug.Log("EnsureShaderAlwaysIncluded: adicionado " + shaderName);
        }

        /// <summary>Build separado (nao mexe em EditorBuildSettings.scenes, que continua so com a
        /// Home) so pra essa validacao - BuildPlayerOptions.scenes substitui a lista pra esta build.</summary>
        public static void BuildAvatarValidationAndroid()
        {
            ConfigureAndroidExternalTools();
            EnsureShaderAlwaysIncluded("Spine/Skeleton");
            PlayerSettings.SetApplicationIdentifier(NamedBuildTarget.Android, "com.c1c3ru.avatarvalidation");
            PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64;
            PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel24;
            PlayerSettings.defaultInterfaceOrientation = UIOrientation.AutoRotation;
            PlayerSettings.allowedAutorotateToLandscapeLeft = true;
            PlayerSettings.allowedAutorotateToLandscapeRight = true;
            PlayerSettings.allowedAutorotateToPortrait = true;
            PlayerSettings.allowedAutorotateToPortraitUpsideDown = true;

            Directory.CreateDirectory("Builds");
            var report = BuildPipeline.BuildPlayer(new BuildPlayerOptions
            {
                scenes = new[] { AvatarValidationScenePath },
                locationPathName = "Builds/AvatarValidation-dev.apk",
                target = BuildTarget.Android,
                options = BuildOptions.Development,
            });
            Debug.Log("ProjectSetup: build validacao avatar " + report.summary.result + " (" + report.summary.totalSize + " bytes)");

            // PlayerSettings (applicationIdentifier, minSdk, orientation) sao de ProjectSettings.asset,
            // um unico arquivo compartilhado com a Home - restaura a identidade real da Home logo apos
            // este build isolado, senao o arquivo fica commitado com a identidade da validacao.
            ConfigureAndroid();

            if (report.summary.result != UnityEditor.Build.Reporting.BuildResult.Succeeded) EditorApplication.Exit(1);
        }
    }
}
