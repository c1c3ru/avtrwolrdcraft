namespace Unity.Services.Authentication;

public static class AuthenticationErrorCodes
{
	public static readonly int MinValue; //Field offset: 0x0
	public static readonly int ClientInvalidUserState; //Field offset: 0x4
	public static readonly int ClientNoActiveSession; //Field offset: 0x8
	public static readonly int InvalidParameters; //Field offset: 0xC
	public static readonly int AccountAlreadyLinked; //Field offset: 0x10
	public static readonly int AccountLinkLimitExceeded; //Field offset: 0x14
	public static readonly int ClientUnlinkExternalIdNotFound; //Field offset: 0x18
	public static readonly int ClientInvalidProfile; //Field offset: 0x1C
	public static readonly int InvalidSessionToken; //Field offset: 0x20
	public static readonly int InvalidProvider; //Field offset: 0x24
	public static readonly int BannedUser; //Field offset: 0x28
	public static readonly int EnvironmentMismatch; //Field offset: 0x2C

	private static AuthenticationErrorCodes() { }

}

