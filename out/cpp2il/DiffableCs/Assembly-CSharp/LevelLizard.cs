//Type is in global namespace

public class LevelLizard : LevelAnimal
{
	internal enum LizardType
	{
		Lizard_A = 0,
	}

	private String[] _idleAnimations; //Field offset: 0x400

	public LevelLizard() { }

	protected virtual bool CanSit() { }

	protected virtual String[] GetIdleAnimations() { }

	protected virtual bool IsSleeping() { }

}

