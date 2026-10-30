namespace UnityEngine;

[RequiredByNativeCode]
public class ResourceRequest : AsyncOperation
{
	internal string m_Path; //Field offset: 0x20
	internal Type m_Type; //Field offset: 0x28

	public object asset
	{
		 get { } //Length: 12
	}

	public ResourceRequest() { }

	public object get_asset() { }

	protected override object GetResult() { }

}

