namespace Game.Level.ContextualAnimation;

public class LevelCAHairDryerItemHandler : LevelCAItemHandlerBase
{
	protected const string Dry_Hair_Self_Animation_Name = "Dry_Hair_Self"; //Field offset: 0x0
	protected const string Dry_Hair_Other_Animation_Name = "Dry_Hair_Other"; //Field offset: 0x0
	private LevelParticleSystemOnDragItemHandler _particleSystemHandler; //Field offset: 0x88
	private LevelSoundOnDragItemHandler _soundHandler; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCAHairDryerItemHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	protected void ToggleEffect(bool state) { }

}

