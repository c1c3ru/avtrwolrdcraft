namespace UnityEngine.AddressableAssets.Initialization;

public static class AddressablesRuntimeProperties
{
	private static Stack<String> s_TokenStack; //Field offset: 0x0
	private static Stack<Int32> s_TokenStartStack; //Field offset: 0x8
	private static bool s_StaticStacksAreInUse; //Field offset: 0x10
	private static Dictionary<String, String> s_CachedValues; //Field offset: 0x18

	private static AddressablesRuntimeProperties() { }

	public static void ClearCachedPropertyValues() { }

	public static string EvaluateProperty(string name) { }

	public static string EvaluateString(string input) { }

	public static string EvaluateString(string inputString, char startDelimiter, char endDelimiter, Func<String, String> varFunc) { }

	private static Assembly[] GetAssemblies() { }

	internal static int GetCachedValueCount() { }

	public static void SetPropertyValue(string name, string val) { }

}

