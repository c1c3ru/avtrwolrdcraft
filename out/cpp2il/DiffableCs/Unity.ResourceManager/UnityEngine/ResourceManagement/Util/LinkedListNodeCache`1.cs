namespace UnityEngine.ResourceManagement.Util;

public class LinkedListNodeCache
{
	private int m_maxNodesAllowed; //Field offset: 0x0
	private int m_NodesCreated; //Field offset: 0x0
	private Stack<LinkedListNode`1<T>> m_NodeCache; //Field offset: 0x0

	internal int CachedNodeCount
	{
		internal get { } //Length: 24
		internal set { } //Length: 212
	}

	internal int CreatedNodeCount
	{
		internal get { } //Length: 8
	}

	public LinkedListNodeCache`1() { }

	public LinkedListNodeCache`1(int maxNodesAllowed, int initialCapacity, int initialPreallocateCount) { }

	public LinkedListNode<T> Acquire(T val) { }

	internal int get_CachedNodeCount() { }

	internal int get_CreatedNodeCount() { }

	private void InitCache(int maxNodesAllowed = 2147483647, int initialCapacity = 10, int initialPreallocateCount = 0) { }

	public void Release(LinkedListNode<T> node) { }

	internal void set_CachedNodeCount(int value) { }

}

