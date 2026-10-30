namespace Game.Level;

public class LevelOnPointerToggleEvent : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private List<UnityEvent> _onStateEventsList; //Field offset: 0x20
	private int _index; //Field offset: 0x28

	public LevelOnPointerToggleEvent() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

