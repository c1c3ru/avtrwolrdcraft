namespace PWC.LevelPhone;

public class DeliveryContentCategoryButton : GameUIElement, IPointerDownHandler, IEventSystemHandler
{
	[SerializeField]
	private int _categoryIndex; //Field offset: 0x24
	[SerializeField]
	private GameObject _indicator; //Field offset: 0x28
	[SerializeField]
	private Image _image; //Field offset: 0x30
	private DeliveryProductsManager _deliveryProductManager; //Field offset: 0x38

	public DeliveryContentCategoryButton() { }

	public void Deselect() { }

	public int GetCategoryType() { }

	public void Init(DeliveryProductsManager deliveryProductManager) { }

	public virtual void OnPointerDown(PointerEventData eventData) { }

	public void SetInitialSelected() { }

	public void SetSelected() { }

	public void SetSprite(Sprite newSprite) { }

}

