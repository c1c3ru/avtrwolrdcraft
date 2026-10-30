//Type is in global namespace

public class LevelBird : LevelAnimal
{
	internal enum BirdType
	{
		Bird_A = 0,
		Bird_B = 3,
		Bird_C = 4,
		Bird_D = 5,
		Bird_E = 6,
	}

	private String[] _idleAnimations; //Field offset: 0x400

	public LevelBird() { }

	protected virtual bool CanSit() { }

	protected virtual String[] GetIdleAnimations() { }

}

