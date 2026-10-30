namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCPlatformConditionHandler : AFCConditionHandlerBase
{
	[SerializeField]
	private PlatformType _platformType; //Field offset: 0x38

	public AFCPlatformConditionHandler() { }

	public virtual bool IsConditionMet() { }

}

