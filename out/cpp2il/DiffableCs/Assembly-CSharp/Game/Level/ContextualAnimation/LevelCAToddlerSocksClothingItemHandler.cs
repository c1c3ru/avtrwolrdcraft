namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerSocksClothingItemHandler : LevelCAItemHandlerBase
{
	private LevelClothingItem _clothingItem; //Field offset: 0x88
	private bool _isDuringEvent; //Field offset: 0x90
	protected LevelToddler _toddler; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAToddlerSocksClothingItemHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

