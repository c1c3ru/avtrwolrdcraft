namespace PazuCore.PazuGameMode;

public class Config
{
	internal class Base
	{
		public bool enabled; //Field offset: 0x10

		public Base() { }

	}

	internal class FTUEClass : Base
	{

		public FTUEClass() { }

	}

	public static readonly Config Default; //Field offset: 0x0
	public FTUEClass FTUE; //Field offset: 0x10

	private static Config() { }

	public Config() { }

}

