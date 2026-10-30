namespace Game.Level;

[AddComponentMenu(null)]
public class LevelSimpleToggleableAudioStationaryItem : LevelStationaryItem, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	protected bool _isOn; //Field offset: 0x60
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x68
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x70
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x78
	[SerializeField]
	private string _soundName; //Field offset: 0x80
	[SerializeField]
	private bool _isLoop; //Field offset: 0x88
	[Range(0.1, 1)]
	[SerializeField]
	private float _volume; //Field offset: 0x8C
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x90

	public LevelSimpleToggleableAudioStationaryItem() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void ToggleParticleSystem() { }

	private void ToggleSound() { }

	private void ToggleSprite() { }

}

