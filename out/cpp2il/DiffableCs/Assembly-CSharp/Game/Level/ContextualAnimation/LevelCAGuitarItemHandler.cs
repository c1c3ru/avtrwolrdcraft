namespace Game.Level.ContextualAnimation;

public class LevelCAGuitarItemHandler : LevelCAItemWithSkinHandlerBase
{
	[SerializeField]
	private int _skinIndex; //Field offset: 0xB0
	[SerializeField]
	private Vector2 _onCharacterLocalPosition; //Field offset: 0xB4
	[SerializeField]
	private float _onCharacterLocalZRotation; //Field offset: 0xBC
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0xC0
	[SerializeField]
	private string _soundName; //Field offset: 0xC8
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0xD0
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0xD8
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xE0

	public LevelCAGuitarItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected virtual string GetBoneName() { }

	public virtual string GetFolderName() { }

	protected virtual string GetSkinName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	protected virtual void OnSkinAdded() { }

	protected virtual void OnSkinRemoved() { }

	private void ParticleSystemSetActive(bool value) { }

	private void SoundPlayerSetActive(bool value) { }

}

