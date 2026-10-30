namespace Game.Level;

public class LevelToggleablePot : LevelStationaryItem, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private GameObject _closedState; //Field offset: 0x60
	[SerializeField]
	private GameObject _openState; //Field offset: 0x68
	[SerializeField]
	private UnityEvent _onOpenedStateEvent; //Field offset: 0x70
	private bool _isOpen; //Field offset: 0x78

	public LevelToggleablePot() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SyncState() { }

}

