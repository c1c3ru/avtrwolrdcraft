namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerInflatableTubeSitAreaHandler : LevelCAParentHandlerBase
{
	[SerializeField]
	private ParticleSystem _particlesPrefab; //Field offset: 0x80
	private LevelToddler _toddler; //Field offset: 0x88
	private BoneFollower _leftBoneFollower; //Field offset: 0x90
	private BoneFollower _rightBoneFollower; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAToddlerInflatableTubeSitAreaHandler() { }

	private void AddParticles() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	protected virtual bool IsAllowedInWaterArea() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void RemoveParticles() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

