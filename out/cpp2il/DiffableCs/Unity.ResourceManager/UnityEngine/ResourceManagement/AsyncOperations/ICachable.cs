namespace UnityEngine.ResourceManagement.AsyncOperations;

internal interface ICachable
{

	public IOperationCacheKey Key
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public IOperationCacheKey get_Key() { }

	public void set_Key(IOperationCacheKey value) { }

}

