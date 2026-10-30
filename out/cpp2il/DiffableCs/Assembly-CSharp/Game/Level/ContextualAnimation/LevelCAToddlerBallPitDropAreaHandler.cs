namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerBallPitDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private LevelBallPitDropArea _dropArea; //Field offset: 0x80
	[SerializeField]
	private Sprite _thumb; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configsStanding; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configsSitting; //Field offset: 0x98
	private LevelToddler _toddler; //Field offset: 0xA0

	public LevelCAToddlerBallPitDropAreaHandler() { }

	private void EnsureStanding(ICATarget target) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

