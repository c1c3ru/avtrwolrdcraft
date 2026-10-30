namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCScreenTypeHandler : AFCConditionHandlerBase
{
	[SerializeField]
	private UScreenType _uScreenType; //Field offset: 0x38

	public AFCScreenTypeHandler() { }

	public virtual bool IsConditionMet() { }

}

