namespace UnityEngine.ResourceManagement.ResourceProviders;

public class InstanceProvider : IInstanceProvider
{
	private Dictionary<GameObject, AsyncOperationHandle`1<GameObject>> m_InstanceObjectToPrefabHandle; //Field offset: 0x10

	public InstanceProvider() { }

	public override GameObject ProvideInstance(ResourceManager resourceManager, AsyncOperationHandle<GameObject> prefabHandle, InstantiationParameters instantiateParameters) { }

	public override void ReleaseInstance(ResourceManager resourceManager, GameObject instance) { }

}

