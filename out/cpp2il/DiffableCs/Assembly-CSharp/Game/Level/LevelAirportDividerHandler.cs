namespace Game.Level;

public class LevelAirportDividerHandler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject, IPointerDownHandler
{
	[SerializeField]
	protected LevelAirportDividerManager _levelAirportDividerManager; //Field offset: 0x20
	[SerializeField]
	private LevelColorChangingLight[] _levelColorChangingLights; //Field offset: 0x28
	[SerializeField]
	protected int _rowNumber; //Field offset: 0x30
	[SerializeField]
	protected int _columnNumber; //Field offset: 0x34
	public int _numberOfConnections; //Field offset: 0x38

	public LevelColorChangingLight[] LevelColorChangingLights
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public int NumberOfConnections
	{
		 get { } //Length: 8
	}

	public LevelAirportDividerHandler() { }

	public void AddConnection() { }

	public LevelColorChangingLight[] get_LevelColorChangingLights() { }

	public int get_NumberOfConnections() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public int GetSelfIndex() { }

	public bool IsNeighboringDivider(LevelAirportDividerHandler other) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	public void RemovedConnection() { }

	public void set_LevelColorChangingLights(LevelColorChangingLight[] value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public virtual string ToString() { }

}

