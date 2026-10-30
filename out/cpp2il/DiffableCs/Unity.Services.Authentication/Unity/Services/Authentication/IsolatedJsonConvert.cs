namespace Unity.Services.Authentication;

internal static class IsolatedJsonConvert
{

	[DebuggerStepThrough]
	public static T DeserializeAnonymousType(string value, T anonymousTypeObject, JsonSerializerSettings settings) { }

	[DebuggerStepThrough]
	public static T DeserializeAnonymousType(string value, T anonymousTypeObject) { }

	[DebuggerStepThrough]
	public static object DeserializeObject(string value, JsonSerializerSettings settings) { }

	public static object DeserializeObject(string value, Type type, JsonSerializerSettings settings) { }

	[DebuggerStepThrough]
	public static object DeserializeObject(string value, Type type, JsonConverter[] converters) { }

	[DebuggerStepThrough]
	public static T DeserializeObject(string value, JsonSerializerSettings settings) { }

	[DebuggerStepThrough]
	public static T DeserializeObject(string value, JsonConverter[] converters) { }

	[DebuggerStepThrough]
	public static T DeserializeObject(string value) { }

	[DebuggerStepThrough]
	public static object DeserializeObject(string value, Type type) { }

	[DebuggerStepThrough]
	public static object DeserializeObject(string value) { }

	public static void PopulateObject(string value, object target, JsonSerializerSettings settings) { }

	[DebuggerStepThrough]
	public static void PopulateObject(string value, object target) { }

	[DebuggerStepThrough]
	public static string SerializeObject(object value, Type type, Formatting formatting, JsonSerializerSettings settings) { }

	[DebuggerStepThrough]
	public static string SerializeObject(object value, Formatting formatting, JsonSerializerSettings settings) { }

	[DebuggerStepThrough]
	public static string SerializeObject(object value, Type type, JsonSerializerSettings settings) { }

	[DebuggerStepThrough]
	public static string SerializeObject(object value, JsonSerializerSettings settings) { }

	[DebuggerStepThrough]
	public static string SerializeObject(object value, Formatting formatting, JsonConverter[] converters) { }

	[DebuggerStepThrough]
	public static string SerializeObject(object value, JsonConverter[] converters) { }

	[DebuggerStepThrough]
	public static string SerializeObject(object value, Formatting formatting) { }

	[DebuggerStepThrough]
	public static string SerializeObject(object value) { }

	private static string SerializeObjectInternal(object value, Type type, JsonSerializer jsonSerializer) { }

}

