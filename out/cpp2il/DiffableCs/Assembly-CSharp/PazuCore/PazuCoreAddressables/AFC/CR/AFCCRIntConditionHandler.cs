namespace PazuCore.PazuCoreAddressables.AFC.CR;

public class AFCCRIntConditionHandler : AFCIntConditionHandlerBase
{
	[SerializeField]
	private string _cloudResponseKey; //Field offset: 0x40
	[SerializeField]
	private int _conditionValue; //Field offset: 0x48
	[SerializeField]
	private String[] _path; //Field offset: 0x50

	public AFCCRIntConditionHandler() { }

	public virtual bool IsConditionMet() { }

}

