namespace Spine.Unity;

[AttributeUsage(384, Inherited = True, AllowMultiple = False)]
public abstract class SpineAttributeBase : PropertyAttribute
{
	public string dataField; //Field offset: 0x10
	public string startsWith; //Field offset: 0x18
	public bool includeNone; //Field offset: 0x20
	public bool fallbackToTextField; //Field offset: 0x21
	public bool avoidGenericMenu; //Field offset: 0x22

	protected SpineAttributeBase() { }

}

