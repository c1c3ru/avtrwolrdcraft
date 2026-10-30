//Type is in global namespace

public class LevelChicken : LevelAnimal
{
	internal enum ChickenType
	{
		Chicken_A = 0,
	}

	private String[] _idleAnimations; //Field offset: 0x400

	public LevelChicken() { }

	protected virtual bool CanSit() { }

	protected virtual String[] GetIdleAnimations() { }

	public virtual bool HasSwimmingAnimations() { }

}

