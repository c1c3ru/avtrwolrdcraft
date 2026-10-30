namespace UnityEngine.ResourceManagement.Util;

public interface IInitializableObject
{

	public bool Initialize(string id, string data) { }

	public AsyncOperationHandle<Boolean> InitializeAsync(ResourceManager rm, string id, string data) { }

}

