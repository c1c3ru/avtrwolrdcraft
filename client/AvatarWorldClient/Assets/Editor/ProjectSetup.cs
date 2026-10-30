using System.IO;
using UnityEditor;
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

            var camGo = new GameObject("Main Camera", typeof(Camera));
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

        public static void ConfigureAndroid()
        {
            PlayerSettings.companyName = "c1c3ru";
            PlayerSettings.productName = "Avatar World (offline)";
            PlayerSettings.SetApplicationIdentifier(NamedBuildTarget.Android, AppId);
            PlayerSettings.SetScriptingBackend(NamedBuildTarget.Android, ScriptingImplementation.IL2CPP);
            PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64;
            PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel24;
            PlayerSettings.defaultInterfaceOrientation = UIOrientation.AutoRotation;
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
