namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCConditionGroupHandler : AFCConditionHandlerBase
{
	internal enum TestType
	{
		None = 0,
		And = 1,
		Or = 2,
	}

	[SerializeField]
	private TestType _testType; //Field offset: 0x38
	[SerializeField]
	private AFCConditionHandlerBase[] _conditionHandlers; //Field offset: 0x40

	public AFCConditionGroupHandler() { }

	public virtual bool IsConditionMet() { }

}

