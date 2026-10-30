namespace Game.Level;

public class LevelTechCat : LevelAnimal
{
	private readonly String[] _overrideIdleAnimations; //Field offset: 0x400

	public LevelTechCat() { }

	protected virtual bool CanEat() { }

	protected virtual String[] GetIdleAnimations() { }

	protected virtual string GetPickUpLoopAnimationName() { }

	protected virtual string GetSittingDownAnimationName() { }

	protected virtual string GetSittingIdleAnimationName() { }

	protected virtual string GetStandingIdleAnimationName() { }

	public virtual bool HasSwimmingAnimations() { }

	protected virtual bool HasWalkingAnimations() { }

}

