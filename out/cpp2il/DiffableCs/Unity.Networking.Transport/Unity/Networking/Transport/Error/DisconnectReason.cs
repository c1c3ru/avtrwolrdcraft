namespace Unity.Networking.Transport.Error;

public enum DisconnectReason
{
	Default = 0,
	Timeout = 1,
	MaxConnectionAttempts = 2,
	ClosedByRemote = 3,
	Count = 4,
}

