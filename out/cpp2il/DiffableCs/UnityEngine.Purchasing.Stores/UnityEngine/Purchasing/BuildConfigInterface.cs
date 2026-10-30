namespace UnityEngine.Purchasing;

internal class BuildConfigInterface
{
	private static Type s_typeCache; //Field offset: 0x0

	public BuildConfigInterface() { }

	internal static string GetApiEndpoint() { }

	private static FieldInfo GetApiEndpointField() { }

	internal static Type GetClassType() { }

	internal static string GetIdEndpoint() { }

	private static FieldInfo GetIdEndpointField() { }

	internal static string GetUdpEndpoint() { }

	private static FieldInfo GetUdpEndpointField() { }

	internal static string GetVersion() { }

	private static FieldInfo GetVersionField() { }

}

