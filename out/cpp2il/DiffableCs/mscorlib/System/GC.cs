namespace System;

public static class GC
{
	internal static readonly object EPHEMERON_TOMBSTONE; //Field offset: 0x0

	public static int MaxGeneration
	{
		 get { } //Length: 76
	}

	private static void _ReRegisterForFinalize(object o) { }

	[ReliabilityContract(Consistency::WillNotCorruptState (3), Cer::Success (2))]
	private static void _SuppressFinalize(object o) { }

	private static GC() { }

	public static void Collect() { }

	[ReliabilityContract(Consistency::WillNotCorruptState (3), Cer::Success (2))]
	public static int CollectionCount(int generation) { }

	private static object get_ephemeron_tombstone() { }

	public static int get_MaxGeneration() { }

	private static int GetCollectionCount(int generation) { }

	private static int GetMaxGeneration() { }

	internal static void GetMemoryInfo(out uint highMemLoadThreshold, out ulong totalPhysicalMem, out uint lastRecordedMemLoad, out UIntPtr lastRecordedHeapSize, out UIntPtr lastRecordedFragmentation) { }

	public static long GetTotalMemory(bool forceFullCollection) { }

	private static void InternalCollect(int generation) { }

	[ReliabilityContract(Consistency::WillNotCorruptState (3), Cer::Success (2))]
	public static void KeepAlive(object obj) { }

	internal static void register_ephemeron_array(Ephemeron[] array) { }

	public static void ReRegisterForFinalize(object obj) { }

	[ReliabilityContract(Consistency::WillNotCorruptState (3), Cer::Success (2))]
	public static void SuppressFinalize(object obj) { }

}

