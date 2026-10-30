namespace UnityEngine.ResourceManagement.Util;

public class LRUCacheAllocationStrategy : IAllocationStrategy
{
	private int m_poolMaxSize; //Field offset: 0x10
	private int m_poolInitialCapacity; //Field offset: 0x14
	private int m_poolCacheMaxSize; //Field offset: 0x18
	private List<List`1<Object>> m_poolCache; //Field offset: 0x20
	private Dictionary<Int32, List`1<Object>> m_cache; //Field offset: 0x28

	public LRUCacheAllocationStrategy(int poolMaxSize, int poolCapacity, int poolCacheMaxSize, int initialPoolCacheCapacity) { }

	private List<Object> GetPool() { }

	public override object New(Type type, int typeHash) { }

	public override void Release(int typeHash, object obj) { }

	private void ReleasePool(List<Object> pool) { }

}

