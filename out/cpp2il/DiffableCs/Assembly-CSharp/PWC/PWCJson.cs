namespace PWC;

public static class PWCJson
{
	private static readonly JsonSerializerSettings _jsonSerializerSettings; //Field offset: 0x0

	private static PWCJson() { }

	[CompilerGenerated]
	internal static void <TryGetInstanceOfType>g__LogError|4_0(object obj, Exception exception = null) { }

	public static JsonSerializerSettings GetJsonSerializerSettings() { }

	public static bool TryDeserialize(string dataString, out T value) { }

	public static bool TryDeserializeFromTextFile(string fileName, out T loadedObject) { }

	public static bool TryGetInstanceOfType(object obj, out T result, bool logErrorOnFailure = true) { }

	public static bool TrySerialize(object value, out string serializedString) { }

	public static bool TrySerializeToFile(string fileName, object value) { }

}

