namespace System.Runtime.Serialization;

[AttributeUsage(28, Inherited = False, AllowMultiple = False)]
public sealed class DataContractAttribute : Attribute
{
	private string name; //Field offset: 0x10
	private bool isNameSetExplicitly; //Field offset: 0x18
	private bool isReference; //Field offset: 0x19

	public bool IsReference
	{
		 get { } //Length: 8
	}

	public string Name
	{
		 set { } //Length: 36
	}

	public DataContractAttribute() { }

	public bool get_IsReference() { }

	public void set_Name(string value) { }

}

