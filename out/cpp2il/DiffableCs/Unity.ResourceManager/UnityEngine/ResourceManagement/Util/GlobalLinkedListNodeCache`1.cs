namespace UnityEngine.ResourceManagement.Util;

internal static class GlobalLinkedListNodeCache
{
	private static LinkedListNodeCache<T> m_globalCache; //Field offset: 0x0

	public static bool CacheExists
	{
		 get { } //Length: 64
	}

	public static LinkedListNode<T> Acquire(T val) { }

	public static bool get_CacheExists() { }

	public static void Release(LinkedListNode<T> node) { }

	public static void SetCacheSize(int length) { }

}

