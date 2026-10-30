namespace Game.Level;

[AddComponentMenu(null)]
public class LevelRadio : LevelStationaryItem, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x60
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x68
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x70
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x78
	private bool _isOn; //Field offset: 0x80

	public LevelRadio() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SyncState() { }

}

