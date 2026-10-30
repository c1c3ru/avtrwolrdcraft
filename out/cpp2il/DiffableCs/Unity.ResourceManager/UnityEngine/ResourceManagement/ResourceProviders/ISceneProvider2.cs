namespace UnityEngine.ResourceManagement.ResourceProviders;

internal interface ISceneProvider2 : ISceneProvider
{

	public AsyncOperationHandle<SceneInstance> ReleaseScene(ResourceManager resourceManager, AsyncOperationHandle<SceneInstance> sceneLoadHandle, UnloadSceneOptions unloadOptions) { }

}

