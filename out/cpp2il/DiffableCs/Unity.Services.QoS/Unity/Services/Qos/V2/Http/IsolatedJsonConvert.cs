namespace Unity.Services.Qos.V2.Http;

internal static class IsolatedJsonConvert
{

	[DebuggerStepThrough]
	public static object DeserializeObject(string value, Type type) { }

	[DebuggerStepThrough]
	public static T DeserializeObject(string value, JsonSerializerSettings settings) { }

	public static object DeserializeObject(string value, Type type, JsonSerializerSettings settings) { }

	[DebuggerStepThrough]
	public static string SerializeObject(object value) { }

	[DebuggerStepThrough]
	public static string SerializeObject(object value, JsonSerializerSettings settings) { }

	[DebuggerStepThrough]
	public static string SerializeObject(object value, Type type, JsonSerializerSettings settings) { }

	private static string SerializeObjectInternal(object value, Type type, JsonSerializer jsonSerializer) { }

}

