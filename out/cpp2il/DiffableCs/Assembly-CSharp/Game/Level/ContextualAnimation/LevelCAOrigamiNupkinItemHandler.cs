namespace Game.Level.ContextualAnimation;

public class LevelCAOrigamiNupkinItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private PDPrefabReference[] _origamiNapkins; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90
	private int _index; //Field offset: 0x98

	public LevelCAOrigamiNupkinItemHandler() { }

	public virtual bool AllowReturnToIdleAnimationWhenRemovedFromTarget() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

