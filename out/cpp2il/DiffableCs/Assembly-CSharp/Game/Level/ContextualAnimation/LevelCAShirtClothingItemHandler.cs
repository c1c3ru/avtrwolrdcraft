namespace Game.Level.ContextualAnimation;

public class LevelCAShirtClothingItemHandler : LevelCAItemHandlerBase
{
	private LevelClothingItem _clothingItem; //Field offset: 0x88
	private bool _isDuringEvent; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCAShirtClothingItemHandler() { }

	protected virtual void Awake() { }

	private void FixOffset() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected virtual void OnReadyPostLoad() { }

	public virtual bool TryOverrideMainThumb(out Sprite spite) { }

}

