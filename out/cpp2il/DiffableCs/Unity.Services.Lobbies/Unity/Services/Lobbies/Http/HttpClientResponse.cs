namespace Unity.Services.Lobbies.Http;

internal class HttpClientResponse
{
	[CompilerGenerated]
	private readonly Dictionary<String, String> <Headers>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly long <StatusCode>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly bool <IsHttpError>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private readonly bool <IsNetworkError>k__BackingField; //Field offset: 0x21
	[CompilerGenerated]
	private readonly Byte[] <Data>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private readonly string <ErrorMessage>k__BackingField; //Field offset: 0x30

	public Byte[] Data
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public string ErrorMessage
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public Dictionary<String, String> Headers
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public bool IsHttpError
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public bool IsNetworkError
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public long StatusCode
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public HttpClientResponse(Dictionary<String, String> headers, long statusCode, bool isHttpError, bool isNetworkError, Byte[] data, string errorMessage) { }

	[CompilerGenerated]
	public Byte[] get_Data() { }

	[CompilerGenerated]
	public string get_ErrorMessage() { }

	[CompilerGenerated]
	public Dictionary<String, String> get_Headers() { }

	[CompilerGenerated]
	public bool get_IsHttpError() { }

	[CompilerGenerated]
	public bool get_IsNetworkError() { }

	[CompilerGenerated]
	public long get_StatusCode() { }

}

