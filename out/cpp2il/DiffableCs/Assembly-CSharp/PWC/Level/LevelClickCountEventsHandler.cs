namespace PWC.Level;

public class LevelClickCountEventsHandler : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler, IHasPersistentData, IRequirePDSceneObject
{
	internal struct ClickCountEvent
	{
		public int RequiredClicks; //Field offset: 0x0
		public UnityEvent OnReached; //Field offset: 0x8

	}

	[SerializeField]
	private List<ClickCountEvent> _clickCountEvents; //Field offset: 0x20
	private int _clickCount; //Field offset: 0x28

	public LevelClickCountEventsHandler() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	private void ProcessClick() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

