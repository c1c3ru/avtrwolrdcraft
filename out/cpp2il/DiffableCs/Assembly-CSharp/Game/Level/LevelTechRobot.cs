namespace Game.Level;

public class LevelTechRobot : LevelAnimal
{
	[SerializeField]
	private LevelCATechRobotHandler _cAHandler; //Field offset: 0x400
	[SerializeField]
	private bool _hasBasketballGame; //Field offset: 0x408
	private String[] _idleAnimations; //Field offset: 0x410
	private String[] _basketballIdleAnimations; //Field offset: 0x418

	public LevelTechRobot() { }

	protected virtual bool CanEat() { }

	protected virtual bool CanSit() { }

	protected virtual String[] GetIdleAnimations() { }

	protected virtual string GetPickUpLoopAnimationName() { }

	protected virtual string GetSittingDownAnimationName() { }

	protected virtual string GetSittingIdleAnimationName() { }

	protected virtual string GetStandingIdleAnimationName() { }

	public virtual bool HasSwimmingAnimations() { }

	protected virtual bool HasWalkingAnimations() { }

}

