//Type is in global namespace

public class LevelFish : LevelAnimal
{
	internal enum FishType
	{
		Fish_A = 0,
		Fish_B = 1,
	}

	private String[] _idleAnimations; //Field offset: 0x400

	public LevelFish() { }

	protected virtual bool CanSit() { }

	protected virtual String[] GetIdleAnimations() { }

	public virtual bool HasSwimmingAnimations() { }

}

