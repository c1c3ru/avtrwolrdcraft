namespace Game.Level;

public class LevelOnPointerClickEvent : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private bool _invokeOnDragging; //Field offset: 0x20
	[SerializeField]
	[Space]
	private UnityEvent _onClickEvent; //Field offset: 0x28

	public LevelOnPointerClickEvent() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public void RemoteClick() { }

}

