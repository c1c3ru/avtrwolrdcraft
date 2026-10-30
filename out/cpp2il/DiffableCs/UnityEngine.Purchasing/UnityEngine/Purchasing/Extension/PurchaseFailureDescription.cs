namespace UnityEngine.Purchasing.Extension;

public class PurchaseFailureDescription
{
	[CompilerGenerated]
	private string <productId>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private PurchaseFailureReason <reason>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private string <message>k__BackingField; //Field offset: 0x20

	public private string message
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private string productId
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private PurchaseFailureReason reason
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public PurchaseFailureDescription(string productId, PurchaseFailureReason reason, string message) { }

	[CompilerGenerated]
	public string get_message() { }

	[CompilerGenerated]
	public string get_productId() { }

	[CompilerGenerated]
	public PurchaseFailureReason get_reason() { }

	[CompilerGenerated]
	private void set_message(string value) { }

	[CompilerGenerated]
	private void set_productId(string value) { }

	[CompilerGenerated]
	private void set_reason(PurchaseFailureReason value) { }

}

