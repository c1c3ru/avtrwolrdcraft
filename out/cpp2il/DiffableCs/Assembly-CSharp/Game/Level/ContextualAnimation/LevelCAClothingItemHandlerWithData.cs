namespace Game.Level.ContextualAnimation;

public class LevelCAClothingItemHandlerWithData : LevelCAItemHandlerBase, IHasCAData
{
	[SerializeField]
	private LevelCAItemHandlerData _caData; //Field offset: 0x88
	private LevelClothingItem _clothingItem; //Field offset: 0x90
	private bool _isDuringEvent; //Field offset: 0x98

	public LevelCAClothingItemHandlerWithData() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private override LevelCAItemHandlerData PWC.LevelContextualAnimation.IHasCAData.GetData() { }

	public virtual bool TryOverrideMainThumb(out Sprite spite) { }

}

