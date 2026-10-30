namespace Game.Store;

public class StorePackWindowIcon : MonoBehaviour
{
	[SerializeField]
	private Image _image; //Field offset: 0x20
	[SerializeField]
	private TextMeshProUGUI _amountText; //Field offset: 0x28
	[SerializeField]
	private TextMeshProUGUI _nameText; //Field offset: 0x30
	[SerializeField]
	private AFCLocalizedTextMeshPro _localizedNameText; //Field offset: 0x38

	public StorePackWindowIcon() { }

	public void Init(Sprite sprite, int amount, string iconName, string nameKey) { }

}

