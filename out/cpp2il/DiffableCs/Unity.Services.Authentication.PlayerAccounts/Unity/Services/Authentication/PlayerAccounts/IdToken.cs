namespace Unity.Services.Authentication.PlayerAccounts;

public class IdToken : BaseJwt
{
	[JsonProperty("aud")]
	public String[] Audience; //Field offset: 0x20
	[CompilerGenerated]
	private string <Email>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private bool <EmailVerified>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private bool <IsPrivateEmail>k__BackingField; //Field offset: 0x31
	[JsonProperty("iss")]
	public string Issuer; //Field offset: 0x38
	[JsonProperty("jti")]
	public string JwtId; //Field offset: 0x40
	[CompilerGenerated]
	private string <Nonce>k__BackingField; //Field offset: 0x48
	[JsonProperty("sub")]
	public string Subject; //Field offset: 0x50

	[JsonProperty("email")]
	public string Email
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	[JsonProperty("email_verified")]
	public bool EmailVerified
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	[JsonProperty("is_private_email")]
	public bool IsPrivateEmail
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	[JsonProperty("nonce")]
	public string Nonce
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	[Preserve]
	internal IdToken() { }

	[CompilerGenerated]
	public string get_Email() { }

	[CompilerGenerated]
	public bool get_EmailVerified() { }

	[CompilerGenerated]
	public bool get_IsPrivateEmail() { }

	[CompilerGenerated]
	public string get_Nonce() { }

	[CompilerGenerated]
	public void set_Email(string value) { }

	[CompilerGenerated]
	public void set_EmailVerified(bool value) { }

	[CompilerGenerated]
	public void set_IsPrivateEmail(bool value) { }

	[CompilerGenerated]
	public void set_Nonce(string value) { }

}

