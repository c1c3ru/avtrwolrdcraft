namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCInstalledGamesAmountConditionHandler : AFCIntConditionHandlerBase
{
	[SerializeField]
	private int _gamesAmount; //Field offset: 0x3C

	public AFCInstalledGamesAmountConditionHandler() { }

	public virtual bool IsConditionMet() { }

}

