namespace Game.Level.ContextualAnimation;

public class LevelCAMusicalInstrumentWithSpecialNamesWithCADataDropAreaHandler : LevelCADropAreaHandlerWithSearchWithData
{
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x98
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0xA0
	[SerializeField]
	private List<String> _soundsName; //Field offset: 0xA8

	public LevelCAMusicalInstrumentWithSpecialNamesWithCADataDropAreaHandler() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	protected void ParticleSystemSetActive(bool value) { }

	protected void SoundPlayerSetActive(bool value, int index, string name) { }

}

