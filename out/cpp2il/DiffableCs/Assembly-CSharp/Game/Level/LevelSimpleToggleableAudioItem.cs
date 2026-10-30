namespace Game.Level;

[AddComponentMenu(null)]
public class LevelSimpleToggleableAudioItem : LevelItem
{
	[SerializeField]
	protected bool _isOn; //Field offset: 0x342
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x348
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x350
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x358
	[SerializeField]
	private string _soundName; //Field offset: 0x360
	[SerializeField]
	private bool _isLoop; //Field offset: 0x368
	[Range(0.1, 1)]
	[SerializeField]
	private float _volume; //Field offset: 0x36C
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x370
	private SpriteRenderer _spriteRenderer; //Field offset: 0x378

	public LevelSimpleToggleableAudioItem() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void ToggleParticleSystem() { }

	private void ToggleSound() { }

	private void ToggleSprite() { }

}

