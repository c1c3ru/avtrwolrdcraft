namespace PWC.Level.ContextualAnimation;

public interface ICATarget
{

	public List<LevelCAHandlerBase> CAHandlers
	{
		 get { } //Length: 0
	}

	public int ContexualAnimationCounter
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public LevelCAConfig CurrentCAConfig
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public LevelCAHandlerBase CurrentCAHandler
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public CAPlayType CurrentCAPlayType
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public bool IsMoving
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public LevelCAHandlerBase LockedCAHandler
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public List<LevelCAHandlerBase> get_CAHandlers() { }

	public int get_ContexualAnimationCounter() { }

	public LevelCAConfig get_CurrentCAConfig() { }

	public LevelCAHandlerBase get_CurrentCAHandler() { }

	public CAPlayType get_CurrentCAPlayType() { }

	public bool get_IsMoving() { }

	public LevelCAHandlerBase get_LockedCAHandler() { }

	public Transform GetTransform() { }

	public void OnAddedCAHandlerWithLockedAnimation(LevelCAHandlerBase handler) { }

	public void OnBeforePlayContextualAnimation() { }

	public void OnCARemoved() { }

	public void ReturnToIdleAnimation() { }

	public void set_ContexualAnimationCounter(int value) { }

	public void set_CurrentCAConfig(LevelCAConfig value) { }

	public void set_CurrentCAHandler(LevelCAHandlerBase value) { }

	public void set_CurrentCAPlayType(CAPlayType value) { }

	public void set_IsMoving(bool value) { }

	public void set_LockedCAHandler(LevelCAHandlerBase value) { }

	public TrackEntry SetAnimation(string animationName, bool loop = false, bool ensureRequiredTextures = false, int trackIndex = 0) { }

	public bool ShouldIncludeInEnsureCheck(LevelCAHandlerBase handler) { }

}

