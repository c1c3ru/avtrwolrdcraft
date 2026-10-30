namespace PWC;

public class GameInputEventTrigger : MonoBehaviour, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IDragHandler, IBeginDragHandler
{
	private GameObject _receiver; //Field offset: 0x20
	private readonly Dictionary<EventTriggerType, Func`3<GameObject, PointerEventData, Boolean>> _preCalls; //Field offset: 0x28

	public GameInputEventTrigger() { }

	private void Awake() { }

	private void Multiplayer_EnsureSceneObject() { }

	private void Multiplayer_OnPrepareForDrag(LevelItem levelItem) { }

	public override void OnBeginDrag(PointerEventData eventData) { }

	public override void OnDrag(PointerEventData eventData) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	public override void OnPointerUp(PointerEventData eventData) { }

	public void SetPreCall(EventTriggerType eventTriggerType, Func<GameObject, PointerEventData, Boolean> action) { }

	public void SetReceiver(GameObject receiver) { }

}

