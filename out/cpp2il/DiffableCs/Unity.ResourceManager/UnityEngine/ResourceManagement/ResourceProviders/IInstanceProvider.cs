namespace UnityEngine.ResourceManagement.ResourceProviders;

public interface IInstanceProvider
{

	public GameObject ProvideInstance(ResourceManager resourceManager, AsyncOperationHandle<GameObject> prefabHandle, InstantiationParameters instantiateParameters) { }

	public void ReleaseInstance(ResourceManager resourceManager, GameObject instance) { }

}

