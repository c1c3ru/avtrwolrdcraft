namespace Game.Level;

public class LevelOnAvatarHandEventItemHandler : MonoBehaviour
{
	[SerializeField]
	private UnityEvent _onPutInAvatarHand; //Field offset: 0x20
	[SerializeField]
	private UnityEvent _onPickUpFromAvatarHand; //Field offset: 0x28
	private LevelItem _levelItem; //Field offset: 0x30
	private bool inAvatarHand; //Field offset: 0x38

	public LevelOnAvatarHandEventItemHandler() { }

	private void Awake() { }

	private void LeaveAvatarHand() { }

	private void OnBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void OnDestroy() { }

	private void OnPlacedOnAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	private void OnRemovedFromAvatar(ILevelAvatar avatar) { }

}

