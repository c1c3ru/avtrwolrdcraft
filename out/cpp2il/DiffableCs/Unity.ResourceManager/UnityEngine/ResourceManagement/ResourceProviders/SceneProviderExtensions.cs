namespace UnityEngine.ResourceManagement.ResourceProviders;

[Extension]
internal static class SceneProviderExtensions
{

	[Extension]
	public static AsyncOperationHandle<SceneInstance> ReleaseScene(ISceneProvider provider, ResourceManager resourceManager, AsyncOperationHandle<SceneInstance> sceneLoadHandle, UnloadSceneOptions unloadOptions) { }

}

