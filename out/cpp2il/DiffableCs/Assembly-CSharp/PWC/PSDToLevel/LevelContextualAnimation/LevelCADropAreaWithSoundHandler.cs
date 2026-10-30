namespace PWC.PSDToLevel.LevelContextualAnimation;

public class LevelCADropAreaWithSoundHandler : LevelCADropAreaHandlerWithData
{
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x98
	[SerializeField]
	private string _soundName; //Field offset: 0xA0
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0xA8

	public LevelCADropAreaWithSoundHandler() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	private void SoundPlayerSetActive(bool value) { }

}

