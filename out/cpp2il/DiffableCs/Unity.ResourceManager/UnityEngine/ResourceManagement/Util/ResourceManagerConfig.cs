namespace UnityEngine.ResourceManagement.Util;

public static class ResourceManagerConfig
{

	public static Array CreateArrayResult(Type type, Object[] allAssets) { }

	public static TObject CreateArrayResult(Object[] allAssets) { }

	public static IList CreateListResult(Type type, Object[] allAssets) { }

	public static TObject CreateListResult(Object[] allAssets) { }

	public static bool ExtractKeyAndSubKey(object keyObj, out string mainKey, out string subKey) { }

	public static bool IsInstance() { }

	public static bool IsPathRemote(string path) { }

	private static bool PlatformCanLoadLocallyFromUrlPath() { }

	public static bool ShouldPathUseWebRequest(string path) { }

	public static string StripQueryParameters(string path) { }

}

