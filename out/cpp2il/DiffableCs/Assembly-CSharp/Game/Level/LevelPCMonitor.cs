namespace Game.Level;

public class LevelPCMonitor : LevelStationaryItem, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private SpriteRenderer _screenImage; //Field offset: 0x60
	[SerializeField]
	private LevelPC _pc; //Field offset: 0x68
	[SerializeField]
	private Sprite[] _pictures; //Field offset: 0x70
	private int _pictureIndex; //Field offset: 0x78

	public LevelPCMonitor() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public void OnPCClick(bool isOn) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SyncState() { }

}

