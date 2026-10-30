namespace Unity.Services.Lobbies;

public class LobbyServiceException : RequestFailedException
{
	[CompilerGenerated]
	private LobbyExceptionReason <Reason>k__BackingField; //Field offset: 0x90

	public ErrorStatus ApiError
	{
		 get { } //Length: 128
	}

	public private LobbyExceptionReason Reason
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public LobbyServiceException(LobbyExceptionReason reason, string message, Exception innerException) { }

	public LobbyServiceException(LobbyExceptionReason reason, string message) { }

	public LobbyServiceException(long errorCode, string message) { }

	public LobbyServiceException(Exception innerException) { }

	public ErrorStatus get_ApiError() { }

	[CompilerGenerated]
	public LobbyExceptionReason get_Reason() { }

	[CompilerGenerated]
	private void set_Reason(LobbyExceptionReason value) { }

}

