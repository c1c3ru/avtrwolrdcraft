namespace Game.Level.ContextualAnimation;

[AddComponentMenu(null)]
public class LevelCAHatClothingItemHandler : LevelCAItemHandlerBase
{
	private LevelClothingItem _clothingItem; //Field offset: 0x88
	private bool _isDuringEvent; //Field offset: 0x90
	private bool _isDuringOnEvent; //Field offset: 0x91
	private bool _isDuringOffEvent; //Field offset: 0x92
	private string _restoreSkinName; //Field offset: 0x98
	private int _restoreCategoryType; //Field offset: 0xA0
	private AvatarSpineSkinsManagerBase _avatarSpineSkinsManager; //Field offset: 0xA8
	private LevelClothingItem _restoreClothingItem; //Field offset: 0xB0
	private LevelCharacter _character; //Field offset: 0xB8
	private bool _isPlayingAnimation; //Field offset: 0xC0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xC8

	public LevelCAHatClothingItemHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected virtual void OnDestroy() { }

	private void OnPreSaveProgress(Scene scene) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private void RemoveHat(LevelCharacter character) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

