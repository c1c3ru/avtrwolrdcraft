namespace Game.Level.Supermarket.FoodDelivery;

public class FoodDeliveryItemsPreview : MonoBehaviour
{
	[SerializeField]
	private FoodDeliveryPreviewItem[] _items; //Field offset: 0x20

	public FoodDeliveryItemsPreview() { }

	public void MarkFoundItems(HashSet<String> prefabGuids) { }

	public void SetVisible(bool isVisible) { }

	public void SyncAppearance(String[] itemsPrefabGuids) { }

}

