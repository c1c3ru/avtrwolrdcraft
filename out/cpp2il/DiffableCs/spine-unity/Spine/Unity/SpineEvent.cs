namespace Spine.Unity;

public class SpineEvent : SpineAttributeBase
{
	public bool audioOnly; //Field offset: 0x23

	public SpineEvent(string startsWith = "", string dataField = "", bool includeNone = true, bool fallbackToTextField = false, bool audioOnly = false) { }

}

