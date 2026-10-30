namespace PWC.Level;

public class LevelBicycleAnimationItemHandler : LevelSkateboardAnimationItemHandlerBase
{
	private bool _cycleFastSpeed; //Field offset: 0x48
	private SkatingMode _currentState; //Field offset: 0x4C

	public SkatingMode CurrentState
	{
		 get { } //Length: 8
	}

	public LevelBicycleAnimationItemHandler() { }

	public SkatingMode get_CurrentState() { }

	public virtual void PlaySuitableIdle(SkatingMode mode, bool isAdd = false) { }

	public void SetCycleSpeed(bool isFast) { }

}

