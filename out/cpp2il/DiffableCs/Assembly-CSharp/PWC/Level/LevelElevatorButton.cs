namespace PWC.Level;

public class LevelElevatorButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler
{
	[SerializeField]
	private LevelElevator _elevator; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x28
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x30
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x38
	[SerializeField]
	private int _floorIndex; //Field offset: 0x40
	private bool _isInteractable; //Field offset: 0x44

	public LevelElevatorButton() { }

	public void ButtonSetActive(bool value) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

}

