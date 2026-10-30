namespace PazuCore.PazuCoreAddressables.AFC.CR;

public class AFCCRStringConditionHandler : AFCConditionHandlerBase
{
	[SerializeField]
	private string _cloudResponseKey; //Field offset: 0x38
	[SerializeField]
	private string _conditionValue; //Field offset: 0x40
	[SerializeField]
	private String[] _path; //Field offset: 0x48

	public AFCCRStringConditionHandler() { }

	public virtual bool IsConditionMet() { }

}

