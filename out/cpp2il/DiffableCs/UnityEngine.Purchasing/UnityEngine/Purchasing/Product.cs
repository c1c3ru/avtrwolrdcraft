namespace UnityEngine.Purchasing;

public class Product
{
	[CompilerGenerated]
	private ProductDefinition <definition>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private ProductMetadata <metadata>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private bool <availableToPurchase>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private string <transactionID>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private string <appleOriginalTransactionID>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private bool <appleProductIsRestored>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private string <receipt>k__BackingField; //Field offset: 0x40

	public internal string appleOriginalTransactionID
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public internal bool appleProductIsRestored
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 12
	}

	public internal bool availableToPurchase
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 12
	}

	public private ProductDefinition definition
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public bool hasReceipt
	{
		 get { } //Length: 32
	}

	public internal ProductMetadata metadata
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public internal string receipt
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public internal string transactionID
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	internal Product(ProductDefinition definition, ProductMetadata metadata, string receipt) { }

	internal Product(ProductDefinition definition, ProductMetadata metadata) { }

	public virtual bool Equals(object obj) { }

	[CompilerGenerated]
	public string get_appleOriginalTransactionID() { }

	[CompilerGenerated]
	public bool get_appleProductIsRestored() { }

	[CompilerGenerated]
	public bool get_availableToPurchase() { }

	[CompilerGenerated]
	public ProductDefinition get_definition() { }

	public bool get_hasReceipt() { }

	[CompilerGenerated]
	public ProductMetadata get_metadata() { }

	[CompilerGenerated]
	public string get_receipt() { }

	[CompilerGenerated]
	public string get_transactionID() { }

	public virtual int GetHashCode() { }

	[CompilerGenerated]
	internal void set_appleOriginalTransactionID(string value) { }

	[CompilerGenerated]
	internal void set_appleProductIsRestored(bool value) { }

	[CompilerGenerated]
	internal void set_availableToPurchase(bool value) { }

	[CompilerGenerated]
	private void set_definition(ProductDefinition value) { }

	[CompilerGenerated]
	internal void set_metadata(ProductMetadata value) { }

	[CompilerGenerated]
	internal void set_receipt(string value) { }

	[CompilerGenerated]
	internal void set_transactionID(string value) { }

}

