namespace Unity.Services.Authentication.Shared;

internal class ApiException : Exception
{
	[CompilerGenerated]
	private ApiExceptionType <Type>k__BackingField; //Field offset: 0x8C
	[CompilerGenerated]
	private IApiResponse <Response>k__BackingField; //Field offset: 0x90

	public private IApiResponse Response
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private ApiExceptionType Type
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public ApiException(ApiExceptionType type, string message, IApiResponse response = null) { }

	[CompilerGenerated]
	public IApiResponse get_Response() { }

	[CompilerGenerated]
	public ApiExceptionType get_Type() { }

	[CompilerGenerated]
	private void set_Response(IApiResponse value) { }

	[CompilerGenerated]
	private void set_Type(ApiExceptionType value) { }

}

