namespace PWC.Level;

public class LevelRollerSkatesAnimationItemHandler : LevelSkateboardAnimationItemHandlerBase
{

	public LevelRollerSkatesAnimationItemHandler() { }

	public virtual void PlayMogglesAnimation(bool isStart) { }

	public virtual void PlayRailAnimation(bool isStart) { }

	public virtual void PlaySuitableIdle(SkatingMode mode, bool isAdd = false) { }

}

