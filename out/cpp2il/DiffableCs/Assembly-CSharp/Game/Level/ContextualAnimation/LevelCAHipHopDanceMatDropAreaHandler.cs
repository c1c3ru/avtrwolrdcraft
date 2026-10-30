namespace Game.Level.ContextualAnimation;

public class LevelCAHipHopDanceMatDropAreaHandler : LevelCADropAreaHandlerWithData
{
	[SerializeField]
	private LevelDropArea _otherDropArea; //Field offset: 0x98
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0xA0
	private LevelCharacter _otherCharacter; //Field offset: 0xA8

	public LevelCAHipHopDanceMatDropAreaHandler() { }

	protected virtual void Awake() { }

	private void CheckOtherCharacter() { }

	public virtual bool IsRelevantForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	protected virtual void OnDestroy() { }

	private void OnItemEndDropAction(LevelItem item) { }

	private void OnItemPickUpAction(LevelItem item) { }

	protected virtual void OnLevelPostInit() { }

}

