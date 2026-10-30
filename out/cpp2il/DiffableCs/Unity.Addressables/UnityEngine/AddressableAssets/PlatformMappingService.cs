namespace UnityEngine.AddressableAssets;

public class PlatformMappingService
{
	internal static readonly Dictionary<RuntimePlatform, AddressablesPlatform> s_RuntimeTargetMapping; //Field offset: 0x0

	private static PlatformMappingService() { }

	public PlatformMappingService() { }

	internal static AddressablesPlatform GetAddressablesPlatformInternal(RuntimePlatform platform) { }

	internal static string GetAddressablesPlatformPathInternal(RuntimePlatform platform) { }

	[Obsolete("This API doesn't adapt to the addition of new platforms.  Use GetPlatformPathSubFolder instead.")]
	public static AddressablesPlatform GetPlatform() { }

	public static string GetPlatformPathSubFolder() { }

}

