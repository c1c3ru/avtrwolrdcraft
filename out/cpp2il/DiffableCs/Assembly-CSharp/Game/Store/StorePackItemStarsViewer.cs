namespace Game.Store;

public class StorePackItemStarsViewer : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _starsText; //Field offset: 0x20
	[SerializeField]
	private GameObject _starsRibbon; //Field offset: 0x28

	public StorePackItemStarsViewer() { }

	public bool TryInit(Item itemData) { }

}

