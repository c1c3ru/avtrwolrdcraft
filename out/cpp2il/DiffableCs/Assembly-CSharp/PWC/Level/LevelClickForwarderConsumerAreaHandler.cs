namespace PWC.Level;

public class LevelClickForwarderConsumerAreaHandler : MonoBehaviour, ILevelMakerDisabledWhileInEditMode
{
	[SerializeField]
	private GameObject _target; //Field offset: 0x20
	private LevelConsumerAreaBase _consumerArea; //Field offset: 0x28

	public LevelClickForwarderConsumerAreaHandler() { }

	private void Awake() { }

	private void OnAvatarBeginDrop(LevelAvatarRestAreaBase restArea, ILevelAvatar avatar) { }

	private void OnAvatarPickUp(LevelAvatarRestAreaBase restArea, ILevelAvatar avatar) { }

	private void OnDestroy() { }

	private void OnItemBeginDrop(LevelItem item) { }

	private void OnItemPickUp(LevelItem item) { }

	public void OnPointerClick(DragDropItemBase dragDropItem, PointerEventData eventData) { }

}

