namespace System.Runtime.Remoting;

[ComVisible(True)]
public class WellKnownClientTypeEntry : TypeEntry
{
	private Type obj_type; //Field offset: 0x20
	private string obj_url; //Field offset: 0x28
	private string app_url; //Field offset: 0x30

	public string ApplicationUrl
	{
		 get { } //Length: 8
	}

	public Type ObjectType
	{
		 get { } //Length: 8
	}

	public string ObjectUrl
	{
		 get { } //Length: 8
	}

	public WellKnownClientTypeEntry(string typeName, string assemblyName, string objectUrl) { }

	public string get_ApplicationUrl() { }

	public Type get_ObjectType() { }

	public string get_ObjectUrl() { }

	public virtual string ToString() { }

}

