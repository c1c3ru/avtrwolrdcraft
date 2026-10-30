namespace Game.Level.ContextualAnimation;

public class LevelCAItemCharacterChangeHairHandler : LevelCAItemHandlerWithData
{
	[SerializeField]
	private bool _isSpriteChange; //Field offset: 0x90
	[ConditionalField("_isSpriteChange", True, True, (array) null)]
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x98
	[ConditionalField("_isSpriteChange", True, True, (array) null)]
	[SerializeField]
	private Sprite _newSprite; //Field offset: 0xA0
	protected string _currentExtraData; //Field offset: 0xA8
	private Sprite _defaultSprite; //Field offset: 0xB0

	public LevelCAItemCharacterChangeHairHandler() { }

	private void AddHairSkinBySpineType(ILevelAvatar avatar, string skinName, int category, bool remove = false) { }

	private void ApplySkin(AvatarSpineSkinsManagerBase skinManager, int category, string skinName, bool remove = false) { }

	private static string ConvertSkinNameToSpineType(SpineType spineType, string skinName) { }

	private void HandleSkinName(ILevelAvatar avatar, string skinName) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected void OnAvatarSetHair(ILevelAvatar avatar) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

}

