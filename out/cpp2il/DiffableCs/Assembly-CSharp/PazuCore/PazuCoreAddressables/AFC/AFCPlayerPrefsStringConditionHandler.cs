namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCPlayerPrefsStringConditionHandler : AFCConditionHandlerBase
{
	internal enum TestType
	{
		None = 0,
		Equal = 1,
		NotEqual = 2,
	}

	[SerializeField]
	private string _playerPrefsKey; //Field offset: 0x38
	[SerializeField]
	private string _value; //Field offset: 0x40
	[SerializeField]
	private TestType _testType; //Field offset: 0x48

	public AFCPlayerPrefsStringConditionHandler() { }

	public virtual bool IsConditionMet() { }

}

