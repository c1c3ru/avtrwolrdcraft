namespace Game.Level.ContextualAnimation;

public class LevelCAGlassesClothingItemHandler : LevelCAItemHandlerBase
{
	private LevelClothingItem _clothingItem; //Field offset: 0x88
	private bool _isDuringEvent; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCAGlassesClothingItemHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public virtual bool TryOverrideMainThumb(out Sprite spite) { }

}

