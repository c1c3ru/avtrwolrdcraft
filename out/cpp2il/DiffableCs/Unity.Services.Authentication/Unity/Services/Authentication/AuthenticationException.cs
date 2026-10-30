namespace Unity.Services.Authentication;

public sealed class AuthenticationException : RequestFailedException
{
	[CompilerGenerated]
	private readonly List<Notification> <Notifications>k__BackingField; //Field offset: 0x90

	public List<Notification> Notifications
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	private AuthenticationException(int errorCode, string message, Exception innerException = null, List<Notification> notifications = null) { }

	public static RequestFailedException Create(int errorCode, string message, Exception innerException = null) { }

	internal static RequestFailedException Create(int errorCode, string message, List<Notification> notifications, Exception innerException = null) { }

	[CompilerGenerated]
	public List<Notification> get_Notifications() { }

}

