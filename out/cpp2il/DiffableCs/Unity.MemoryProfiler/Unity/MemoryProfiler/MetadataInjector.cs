namespace Unity.MemoryProfiler;

internal static class MetadataInjector
{
	public static DefaultMetadataCollect DefaultCollector; //Field offset: 0x0
	public static long CollectorCount; //Field offset: 0x8
	public static byte DefaultCollectorInjected; //Field offset: 0x10

	private static void InitializeMetadataCollection() { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSplashScreen (3))]
	private static void PlayerInitMetadata() { }

}

