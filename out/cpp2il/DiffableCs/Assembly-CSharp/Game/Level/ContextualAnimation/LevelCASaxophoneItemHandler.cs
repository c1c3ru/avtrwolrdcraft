namespace Game.Level.ContextualAnimation;

public class LevelCASaxophoneItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private Vector2 _onCharacterLocalPosition; //Field offset: 0x88
	[SerializeField]
	private float _onCharacterLocalZRotation; //Field offset: 0x90
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x98
	[SerializeField]
	private string _soundName; //Field offset: 0xA0
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0xA8
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0xB0

	public LevelCASaxophoneItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	private void ParticleSystemSetActive(bool value) { }

	private void SoundPlayerSetActive(bool value) { }

}

