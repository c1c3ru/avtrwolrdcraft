namespace Game.Level.ContextualAnimation;

public abstract class LevelCAMusicalInstrumentItemHandlerBase : LevelCAItemWithSkinHandlerBase
{
	[SerializeField]
	protected int _skinIndex; //Field offset: 0xB0
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0xB8
	[SerializeField]
	private string _soundName; //Field offset: 0xC0
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0xC8
	[SerializeField]
	private List<String> _soundsName; //Field offset: 0xD0

	protected LevelCAMusicalInstrumentItemHandlerBase() { }

	protected virtual void Awake() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	protected virtual void OnSkinAdded() { }

	protected virtual void OnSkinRemoved() { }

	private void ParticleSystemSetActive(bool value) { }

	private void SoundPlayerSetActive(bool value, int index, string name) { }

}

