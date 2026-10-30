namespace Unity.Services.Core;

public class RequestFailedException : Exception
{
	[CompilerGenerated]
	private readonly int <ErrorCode>k__BackingField; //Field offset: 0x8C

	public int ErrorCode
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public RequestFailedException(int errorCode, string message) { }

	public RequestFailedException(int errorCode, string message, Exception innerException) { }

	[CompilerGenerated]
	public int get_ErrorCode() { }

}

