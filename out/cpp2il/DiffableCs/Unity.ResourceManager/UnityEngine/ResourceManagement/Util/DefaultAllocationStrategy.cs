namespace UnityEngine.ResourceManagement.Util;

public class DefaultAllocationStrategy : IAllocationStrategy
{

	public DefaultAllocationStrategy() { }

	public override object New(Type type, int typeHash) { }

	public override void Release(int typeHash, object obj) { }

}

