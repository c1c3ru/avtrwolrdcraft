namespace Game.Level;

public class LevelFireplaceButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private FireplaceButtonType _buttonType; //Field offset: 0x20
	[SerializeField]
	private LevelFireplace _fireplace; //Field offset: 0x28
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x30
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x38
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x40
	private bool _isInteractable; //Field offset: 0x48

	public LevelFireplaceButton() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public void ResetStateIfNeeded(FireplaceButtonType buttonType) { }

	public void SetInteractable(bool value) { }

}

