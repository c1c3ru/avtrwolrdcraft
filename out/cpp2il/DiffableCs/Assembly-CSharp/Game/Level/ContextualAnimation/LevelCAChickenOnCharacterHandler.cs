namespace Game.Level.ContextualAnimation;

public class LevelCAChickenOnCharacterHandler : LevelCAPetOnCharacterHandlerBase
{
	private bool _isOnHead; //Field offset: 0x99
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAChickenOnCharacterHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected virtual string GetBoneName() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	protected virtual Nullable<Vector2> GetPivotOnBone() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected virtual void OnReadyPostLoad() { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	public virtual bool TryOverrideConfigThumb(int configIndex, out Sprite sprite) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

