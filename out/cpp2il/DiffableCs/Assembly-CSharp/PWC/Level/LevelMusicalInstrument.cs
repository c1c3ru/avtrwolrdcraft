namespace PWC.Level;

[AddComponentMenu(null)]
public class LevelMusicalInstrument : LevelItemOnCharacterBase
{
	[SerializeField]
	private Vector2 _onCharacterLocalPosition; //Field offset: 0x358
	[SerializeField]
	private float _onCharacterLocalZRotation; //Field offset: 0x360
	[SerializeField]
	private string _boneName; //Field offset: 0x368
	[SerializeField]
	private string _animationName; //Field offset: 0x370
	[SerializeField]
	private string _soundName; //Field offset: 0x378
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x380
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x388

	public LevelMusicalInstrument() { }

	protected virtual string GetCharacterAnimationName() { }

	protected virtual string GetCharacterBoneName() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	public virtual void OnPlacedOnAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

}

