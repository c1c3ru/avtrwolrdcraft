namespace Game.Level;

public class LevelHockeyStrikerItemHandler : LevelDragActionItemHandlerBase
{

	public LevelHockeyStrikerItemHandler() { }

	protected virtual void Awake() { }

	private void CheckForHockeyDropArea(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnTargetEnter(ILevelConsumer target) { }

	protected virtual void OnTargetExit(ILevelConsumer target, ExitReasonType exitReasonType) { }

}

