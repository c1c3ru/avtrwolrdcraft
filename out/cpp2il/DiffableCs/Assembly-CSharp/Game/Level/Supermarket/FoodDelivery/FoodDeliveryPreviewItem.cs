namespace Game.Level.Supermarket.FoodDelivery;

public class FoodDeliveryPreviewItem : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	private GameObject _doneIndicator; //Field offset: 0x28
	private PDPrefab _pdPrefab; //Field offset: 0x30

	public FoodDeliveryPreviewItem() { }

	public string GetPDPrefabGuid() { }

	public SpriteRenderer GetSpriteRenderer() { }

	public void Init(PDPrefab pdPrefab) { }

	public void SetVisible(bool isVisible) { }

	public void ShowDoneIndicator(bool show) { }

}

