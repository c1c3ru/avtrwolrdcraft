namespace Game.Level;

public class LevelKeyShakingDoor : LevelDragActionItemHandlerBase
{
	[SerializeField]
	private bool _isDisappearingAfterOpen; //Field offset: 0xA0
	private LevelShakingDoor _door; //Field offset: 0xA8
	private ILevelAvatar _currentHoldingAvatar; //Field offset: 0xB0

	public LevelKeyShakingDoor() { }

	protected virtual void Awake() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	private void OnBeforeDetachFromParentAction(LevelItem levelItem, Transform transform) { }

	private void OnCharacterSpineEvent(Event spineEvent) { }

	protected virtual void OnDestroy() { }

	private void OnPlacedOnCharacter(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	protected virtual void OnTargetEnter(ILevelConsumer target) { }

	protected virtual void OnTargetExit(ILevelConsumer target, ExitReasonType exitReasonType) { }

}

