namespace PWC.Level;

public class LevelSnowboardAnimationItemHandler : LevelSkateboardAnimationItemHandler
{

	public LevelSnowboardAnimationItemHandler() { }

	public virtual void PlayMogglesAnimation(bool isStart) { }

	public virtual void PlayRailAnimation(bool isStart) { }

	public virtual void PlaySuitableIdle(SkatingMode mode, bool isAdd = false) { }

}

