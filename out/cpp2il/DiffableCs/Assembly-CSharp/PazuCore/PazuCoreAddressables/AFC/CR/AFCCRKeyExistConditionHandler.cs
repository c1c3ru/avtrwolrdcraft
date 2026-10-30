namespace PazuCore.PazuCoreAddressables.AFC.CR;

public class AFCCRKeyExistConditionHandler : AFCConditionHandlerBase
{
	[SerializeField]
	private string _cloudResponseKey; //Field offset: 0x38
	[SerializeField]
	private String[] _path; //Field offset: 0x40

	public AFCCRKeyExistConditionHandler() { }

	public virtual bool IsConditionMet() { }

}

