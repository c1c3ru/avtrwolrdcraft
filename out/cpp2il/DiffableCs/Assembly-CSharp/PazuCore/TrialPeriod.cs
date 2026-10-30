namespace PazuCore;

public class TrialPeriod
{
	internal enum UnitType
	{
		Day = 0,
		Week = 1,
		Month = 2,
		Year = 3,
	}

	public readonly UnitType unitType; //Field offset: 0x10
	public readonly int number; //Field offset: 0x14

	public TrialPeriod(UnitType unitType, int number) { }

	public int GetDays() { }

}

