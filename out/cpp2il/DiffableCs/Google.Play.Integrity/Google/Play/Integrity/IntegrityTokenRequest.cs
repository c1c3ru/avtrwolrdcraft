namespace Google.Play.Integrity;

public class IntegrityTokenRequest
{
	[CompilerGenerated]
	private string <Nonce>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private Nullable<Int64> <CloudProjectNumber>k__BackingField; //Field offset: 0x18

	public private Nullable<Int64> CloudProjectNumber
	{
		[CompilerGenerated]
		 get { } //Length: 12
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private string Nonce
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public IntegrityTokenRequest(string nonce, Nullable<Int64> cloudProjectNumber = null) { }

	[CompilerGenerated]
	public Nullable<Int64> get_CloudProjectNumber() { }

	[CompilerGenerated]
	public string get_Nonce() { }

	[CompilerGenerated]
	private void set_CloudProjectNumber(Nullable<Int64> value) { }

	[CompilerGenerated]
	private void set_Nonce(string value) { }

}

