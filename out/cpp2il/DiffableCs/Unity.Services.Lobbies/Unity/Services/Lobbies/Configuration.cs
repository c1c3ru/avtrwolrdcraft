namespace Unity.Services.Lobbies;

internal class Configuration
{
	public string BasePath; //Field offset: 0x10
	public Nullable<Int32> RequestTimeout; //Field offset: 0x18
	public Nullable<Int32> NumberOfRetries; //Field offset: 0x20
	public IDictionary<String, String> Headers; //Field offset: 0x28

	public Configuration(string basePath, Nullable<Int32> requestTimeout, Nullable<Int32> numRetries, IDictionary<String, String> headers) { }

	public static Configuration MergeConfigurations(Configuration a, Configuration b) { }

}

