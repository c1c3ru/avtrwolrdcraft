namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCInstalledGamesConditionHandler : AFCConditionHandlerBase
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
	private Int32[] _gameIds; //Field offset: 0x40

	public AFCInstalledGamesConditionHandler() { }

	public virtual bool IsConditionMet() { }

}

