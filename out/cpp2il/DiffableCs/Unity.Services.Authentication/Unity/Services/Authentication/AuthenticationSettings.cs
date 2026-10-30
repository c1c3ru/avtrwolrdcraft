namespace Unity.Services.Authentication;

internal class AuthenticationSettings : IAuthenticationSettings
{
	private const int k_AccessTokenRefreshBuffer = 300; //Field offset: 0x0
	private const int k_AccessTokenExpiryBuffer = 15; //Field offset: 0x0
	private const int k_RefreshAttemptFrequency = 30; //Field offset: 0x0
	private const int k_CodeConfirmationDelay = 5; //Field offset: 0x0
	[CompilerGenerated]
	private int <AccessTokenRefreshBuffer>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private int <AccessTokenExpiryBuffer>k__BackingField; //Field offset: 0x14
	[CompilerGenerated]
	private int <RefreshAttemptFrequency>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private int <CodeConfirmationAttempts>k__BackingField; //Field offset: 0x1C
	[CompilerGenerated]
	private int <CodeConfirmationDelay>k__BackingField; //Field offset: 0x20

	public internal override int AccessTokenExpiryBuffer
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public internal override int AccessTokenRefreshBuffer
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public internal override int CodeConfirmationAttempts
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public internal override int CodeConfirmationDelay
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public internal override int RefreshAttemptFrequency
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	internal AuthenticationSettings() { }

	[CompilerGenerated]
	public override int get_AccessTokenExpiryBuffer() { }

	[CompilerGenerated]
	public override int get_AccessTokenRefreshBuffer() { }

	[CompilerGenerated]
	public override int get_CodeConfirmationAttempts() { }

	[CompilerGenerated]
	public override int get_CodeConfirmationDelay() { }

	[CompilerGenerated]
	public override int get_RefreshAttemptFrequency() { }

	internal void Reset() { }

	[CompilerGenerated]
	internal void set_AccessTokenExpiryBuffer(int value) { }

	[CompilerGenerated]
	internal void set_AccessTokenRefreshBuffer(int value) { }

	[CompilerGenerated]
	internal void set_CodeConfirmationAttempts(int value) { }

	[CompilerGenerated]
	internal void set_CodeConfirmationDelay(int value) { }

	[CompilerGenerated]
	internal void set_RefreshAttemptFrequency(int value) { }

}

