namespace UnityEngine.ResourceManagement.Util;

public interface IAllocationStrategy
{

	public object New(Type type, int typeHash) { }

	public void Release(int typeHash, object obj) { }

}

