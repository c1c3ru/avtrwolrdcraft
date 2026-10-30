//Type is in global namespace

public class LevelHamster : LevelAnimal
{
	internal enum HamsterType
	{
		Hamster_A = 0,
		Hamster_B = 1,
	}

	private String[] _idleAnimations; //Field offset: 0x400

	public LevelHamster() { }

	protected virtual bool CanSit() { }

	protected virtual String[] GetIdleAnimations() { }

}

