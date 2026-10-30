namespace Unity.Services.Authentication;

internal class WebRequestException : Exception
{
	[CompilerGenerated]
	private bool <NetworkError>k__BackingField; //Field offset: 0x8C
	[CompilerGenerated]
	private bool <DeserializationError>k__BackingField; //Field offset: 0x8D
	[CompilerGenerated]
	private bool <ServerError>k__BackingField; //Field offset: 0x8E
	[CompilerGenerated]
	private long <ResponseCode>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private IDictionary<String, String> <ResponseHeaders>k__BackingField; //Field offset: 0x98

	public private bool DeserializationError
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private bool NetworkError
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private long ResponseCode
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private IDictionary<String, String> ResponseHeaders
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private bool ServerError
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	internal WebRequestException(bool isNetworkError, bool isServerError, bool isDeserializationError, long responseCode, string errorMessage, IDictionary<String, String> responseHeaders = null) { }

	[CompilerGenerated]
	public bool get_DeserializationError() { }

	[CompilerGenerated]
	public bool get_NetworkError() { }

	[CompilerGenerated]
	public long get_ResponseCode() { }

	[CompilerGenerated]
	public IDictionary<String, String> get_ResponseHeaders() { }

	[CompilerGenerated]
	public bool get_ServerError() { }

	[CompilerGenerated]
	private void set_DeserializationError(bool value) { }

	[CompilerGenerated]
	private void set_NetworkError(bool value) { }

	[CompilerGenerated]
	private void set_ResponseCode(long value) { }

	[CompilerGenerated]
	private void set_ResponseHeaders(IDictionary<String, String> value) { }

	[CompilerGenerated]
	private void set_ServerError(bool value) { }

}

