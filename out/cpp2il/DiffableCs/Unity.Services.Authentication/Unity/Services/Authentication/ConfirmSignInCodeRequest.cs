namespace Unity.Services.Authentication;

internal class ConfirmSignInCodeRequest
{
	[CompilerGenerated]
	private string <SignInCode>k__BackingField; //Field offset: 0x10
	[JsonProperty("idProvider")]
	public string IdProvider; //Field offset: 0x18
	[JsonProperty("externalToken")]
	public string ExternalToken; //Field offset: 0x20
	[JsonProperty("sessionToken")]
	public string SessionToken; //Field offset: 0x28

	[JsonProperty("signInCode")]
	public string SignInCode
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public ConfirmSignInCodeRequest() { }

	[CompilerGenerated]
	public string get_SignInCode() { }

	[CompilerGenerated]
	public void set_SignInCode(string value) { }

}

