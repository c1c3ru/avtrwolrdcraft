namespace System.Runtime.Remoting;

[ComVisible(True)]
public class ActivatedClientTypeEntry : TypeEntry
{
	private string applicationUrl; //Field offset: 0x20
	private Type obj_type; //Field offset: 0x28

	public string ApplicationUrl
	{
		 get { } //Length: 8
	}

	public IContextAttribute[] ContextAttributes
	{
		 get { } //Length: 8
	}

	public Type ObjectType
	{
		 get { } //Length: 8
	}

	public ActivatedClientTypeEntry(string typeName, string assemblyName, string appUrl) { }

	public string get_ApplicationUrl() { }

	public IContextAttribute[] get_ContextAttributes() { }

	public Type get_ObjectType() { }

	public virtual string ToString() { }

}

