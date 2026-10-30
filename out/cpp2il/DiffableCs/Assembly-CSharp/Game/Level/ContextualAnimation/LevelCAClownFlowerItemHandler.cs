namespace Game.Level.ContextualAnimation;

public class LevelCAClownFlowerItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private GameObject _particleSystem; //Field offset: 0x88
	[SerializeField]
	private LevelToggleableParticleSystem _toggleableParticleSystem; //Field offset: 0x90
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x98
	[SerializeField]
	private string _soundName; //Field offset: 0xA0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA8

	public LevelCAClownFlowerItemHandler() { }

	[CompilerGenerated]
	private void <PlayParticles>b__8_0() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void PlayParticles() { }

	private void StartSound() { }

}

