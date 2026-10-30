namespace Game.Level.ContextualAnimation;

public class LevelCAItemCharacterChangeSkinHandler : LevelCAItemHandlerWithData
{
	private const string REMOVE_KEYWORD = "Remove"; //Field offset: 0x0
	private static readonly Dictionary<String, Int32> _categoryTypeByEnumAndName; //Field offset: 0x0
	[SerializeField]
	[Tooltip("Which skin category this item changes. The skin name comes from the CA extraData.")]
	private CharacterCategoryType _categoryType; //Field offset: 0x90
	[SerializeField]
	private bool _isSpriteChange; //Field offset: 0x94
	[ConditionalField("_isSpriteChange", True, True, (array) null)]
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x98
	[ConditionalField("_isSpriteChange", True, True, (array) null)]
	[SerializeField]
	private Sprite _newSprite; //Field offset: 0xA0
	[SerializeField]
	[Tooltip("Destroy this item once a skin was actually applied. The item is destroyed when the animation ends, or earlier on a Destroy_Item spine event. A 'Remove' extraData never destroys the item - that item is a tool, not a consumable.")]
	private bool _isDestroyItemOnSkinChange; //Field offset: 0xA8
	[ConditionalField("_isDestroyItemOnSkinChange", True, True, (array) null)]
	[SerializeField]
	private bool _isPoofEffect; //Field offset: 0xA9
	[ConditionalField("_isPoofEffect", True, True, (array) null)]
	[SerializeField]
	private Color _poofColor; //Field offset: 0xAC
	protected string _currentExtraData; //Field offset: 0xC0
	private bool _didAddSkin; //Field offset: 0xC8
	private AvatarSpineSkinsManagerBase _originalSkinsManager; //Field offset: 0xD0
	private string _originalSkinName; //Field offset: 0xD8
	private Sprite _defaultSprite; //Field offset: 0xE0

	private static LevelCAItemCharacterChangeSkinHandler() { }

	public LevelCAItemCharacterChangeSkinHandler() { }

	private string BuildSkinName(SpineType spineType, string entry) { }

	private static string ConvertSkinNameToSpineType(SpineType spineType, string skinName) { }

	private void DestroyItem() { }

	private void EnsureOriginalSkinName(AvatarSpineSkinsManagerBase skinsManager, int categoryType) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected void OnAvatarSetSkin(ILevelAvatar avatar) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private bool RemoveOrRestoreSkin(AvatarSpineSkinsManagerBase skinsManager, int categoryType) { }

	protected override bool ShouldApplyToCATarget() { }

	private bool TryResolveCategoryType(SpineType spineType, out int categoryType) { }

}

