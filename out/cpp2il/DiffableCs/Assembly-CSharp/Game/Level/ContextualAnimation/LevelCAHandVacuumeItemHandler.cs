namespace Game.Level.ContextualAnimation;

public class LevelCAHandVacuumeItemHandler : LevelCAItemHandlerBase
{
	protected const string EMPTY_DUST_ANIMATION_NAME = "Empty_Dust"; //Field offset: 0x0
	private LevelParticleSystemOnDragItemHandler _particleSystemHandler; //Field offset: 0x88
	private LevelSoundOnDragItemHandler _soundHandler; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCAHandVacuumeItemHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	protected override void ShowParticles() { }

	protected override void StopParticles() { }

}

