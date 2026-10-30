namespace PWC.LevelPhone;

public class VehiclesCategoryButton : GameUIElement, IPointerDownHandler, IEventSystemHandler
{
	[SerializeField]
	private VehiclesCategoryType _categoryType; //Field offset: 0x24
	[SerializeField]
	private GameObject _indicator; //Field offset: 0x28
	[SerializeField]
	private Image _image; //Field offset: 0x30
	[SerializeField]
	private Sprite _disabledSprite; //Field offset: 0x38
	private VehicleContent _contentMenu; //Field offset: 0x40
	private bool _isDisabled; //Field offset: 0x48

	public VehiclesCategoryButton() { }

	public void Deselect() { }

	public VehiclesCategoryType GetCategoryType() { }

	public void Init(VehicleContent contentMenu) { }

	public virtual void OnPointerDown(PointerEventData eventData) { }

	public void SetDisabled() { }

	public void SetSelected() { }

}

