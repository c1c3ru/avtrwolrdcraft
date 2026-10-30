//Type is in global namespace

public class LevelCow : LevelAnimal
{
	internal enum CowType
	{
		Cow_A = 0,
	}

	private String[] _idleAnimations; //Field offset: 0x400

	public LevelCow() { }

	public virtual bool CanBeDroppedOn(LevelDropArea dropArea) { }

	protected virtual bool CanSit() { }

	protected virtual String[] GetIdleAnimations() { }

	public virtual bool HasSwimmingAnimations() { }

}

