namespace PWC.Level.Maker.Customization;

public class PalettePreviewCustomizationUIItem : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	private const int COLOR_ITEMS_COUNT = 4; //Field offset: 0x0
	[SerializeField]
	private Image _background; //Field offset: 0x20
	[SerializeField]
	private TextMeshProUGUI _headlineText; //Field offset: 0x28
	[SerializeField]
	private Transform _view; //Field offset: 0x30
	[SerializeField]
	private PaletteColorCustomizationUIItem _colorItemPrefab; //Field offset: 0x38
	private LevelMakerItemAllPalettesMenu _menu; //Field offset: 0x40
	private LevelMakerCustomizationObjectHandlerBase _objectHandler; //Field offset: 0x48
	private PaletteColorCustomizationUIItem[] _colorList; //Field offset: 0x50
	private LevelMakerCCBase[] _configs; //Field offset: 0x58
	private string _category; //Field offset: 0x60

	public Image Background
	{
		 get { } //Length: 8
	}

	public PalettePreviewCustomizationUIItem() { }

	public Image get_Background() { }

	public void Init(LevelMakerItemAllPalettesMenu itemCustomizationPalettesMenu, LevelMakerCustomizationObjectHandlerBase objectHandler, string category, LevelMakerCCBase[] finalConfigsList, string packName, Color[] colors) { }

	private void OnEnable() { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

