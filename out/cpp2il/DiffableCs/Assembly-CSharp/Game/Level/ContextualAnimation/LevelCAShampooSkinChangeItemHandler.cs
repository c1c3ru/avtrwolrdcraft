namespace Game.Level.ContextualAnimation;

public class LevelCAShampooSkinChangeItemHandler : LevelCAShampooItemHandler
{
	[SerializeField]
	protected LevelMakeupDataItemHandler _makeupDataItemHandler; //Field offset: 0x90
	[SerializeField]
	private CharacterCategoryType _skinToRemove; //Field offset: 0x98
	private bool _isSkinApplied; //Field offset: 0x9C

	public LevelCAShampooSkinChangeItemHandler() { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

