namespace PazuCore.PazuCoreAddressables.AFC;

public abstract class AFCIntConditionHandlerBase : AFCConditionHandlerBase
{
	internal enum TestType
	{
		None = 0,
		Equal = 1,
		NotEqual = 2,
		GEqual = 3,
		LEqual = 4,
		Greater = 5,
		Less = 6,
		DivisibleBy = 7,
	}

	[SerializeField]
	private TestType _testType; //Field offset: 0x38

	protected AFCIntConditionHandlerBase() { }

	protected bool RunTest(int value, int conditionValue) { }

}

