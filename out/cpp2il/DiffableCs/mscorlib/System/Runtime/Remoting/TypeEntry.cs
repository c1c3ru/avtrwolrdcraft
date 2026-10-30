namespace System.Runtime.Remoting;

[ComVisible(True)]
public class TypeEntry
{
	private string assembly_name; //Field offset: 0x10
	private string type_name; //Field offset: 0x18

	public string AssemblyName
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public string TypeName
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	protected TypeEntry() { }

	public string get_AssemblyName() { }

	public string get_TypeName() { }

	public void set_AssemblyName(string value) { }

	public void set_TypeName(string value) { }

}

