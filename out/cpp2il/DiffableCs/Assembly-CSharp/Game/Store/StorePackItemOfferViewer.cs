namespace Game.Store;

public class StorePackItemOfferViewer : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _specialOfferText; //Field offset: 0x20
	[SerializeField]
	private GameObject _specialOfferRibbon; //Field offset: 0x28
	private Item _itemData; //Field offset: 0x30

	public StorePackItemOfferViewer() { }

	public void Init(Item itemData) { }

}

