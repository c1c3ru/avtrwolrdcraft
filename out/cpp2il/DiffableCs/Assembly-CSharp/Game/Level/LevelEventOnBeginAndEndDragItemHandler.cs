namespace Game.Level;

public class LevelEventOnBeginAndEndDragItemHandler : MonoBehaviour
{
	[Header("On Pick Up Events")]
	[SerializeField]
	[Space]
	private UnityEvent _onPickUpEvent; //Field offset: 0x20
	[Header("On End Drop Events")]
	[SerializeField]
	[Space]
	private UnityEvent _onEndDropEvent; //Field offset: 0x28
	private DragDropItemBase _item; //Field offset: 0x30

	public LevelEventOnBeginAndEndDragItemHandler() { }

	protected override void Awake() { }

	private void OnBeginDragAction(DragDropItemBase arg1, PointerEventData arg2) { }

	private void OnDestroy() { }

	private void OnEndDragAction(DragDropItemBase base, PointerEventData data) { }

}

