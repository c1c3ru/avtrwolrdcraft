namespace PazuCore.AF.Library;

public class LibraryGameBadge : MonoBehaviour
{
	[SerializeField]
	private Image _image; //Field offset: 0x20
	[SerializeField]
	private Text _text; //Field offset: 0x28
	[SerializeField]
	private Image _top10Image; //Field offset: 0x30
	[SerializeField]
	private Text _top10Text; //Field offset: 0x38

	public LibraryGameBadge() { }

	public void Init(LibraryGame game) { }

}

