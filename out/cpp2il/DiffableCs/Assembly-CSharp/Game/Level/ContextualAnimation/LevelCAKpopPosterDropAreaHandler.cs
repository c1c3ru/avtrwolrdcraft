namespace Game.Level.ContextualAnimation;

public class LevelCAKpopPosterDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private int _uniqueAvatarID; //Field offset: 0x80
	[SerializeField]
	private UnityEvent _signingEvent; //Field offset: 0x88
	private LevelCharacter _character; //Field offset: 0x90

	public LevelCAKpopPosterDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

