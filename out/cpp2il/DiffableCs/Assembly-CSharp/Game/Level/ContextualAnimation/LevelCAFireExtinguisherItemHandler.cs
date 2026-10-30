namespace Game.Level.ContextualAnimation;

public class LevelCAFireExtinguisherItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x88
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x90
	[SerializeField]
	private string _soundName; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAFireExtinguisherItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void ToggleParticleSystem(bool value) { }

	private void ToggleSoundPlayer(bool value) { }

}

