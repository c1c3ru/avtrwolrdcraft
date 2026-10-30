namespace Unity.Services.Relay;

public class RelayServiceException : RequestFailedException
{
	[CompilerGenerated]
	private RelayExceptionReason <Reason>k__BackingField; //Field offset: 0x90

	public private RelayExceptionReason Reason
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public RelayServiceException(RelayExceptionReason reason, string message, Exception innerException) { }

	public RelayServiceException(RelayExceptionReason reason, string message) { }

	public RelayServiceException(long errorCode, string message) { }

	public RelayServiceException(Exception innerException) { }

	[CompilerGenerated]
	public RelayExceptionReason get_Reason() { }

	[CompilerGenerated]
	private void set_Reason(RelayExceptionReason value) { }

}

