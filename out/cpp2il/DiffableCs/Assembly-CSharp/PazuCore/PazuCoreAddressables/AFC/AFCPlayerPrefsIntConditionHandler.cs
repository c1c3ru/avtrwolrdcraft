namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCPlayerPrefsIntConditionHandler : AFCIntConditionHandlerBase
{
	[SerializeField]
	private string _playerPrefsKey; //Field offset: 0x40
	[SerializeField]
	private int _value; //Field offset: 0x48

	public AFCPlayerPrefsIntConditionHandler() { }

	public virtual bool IsConditionMet() { }

}

