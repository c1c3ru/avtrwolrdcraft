namespace PWC.Level.Maker;

public class LevelMakerItemAllPalettesMenu : MonoBehaviour
{
	[SerializeField]
	private LevelMakerItemCustomizationMenu _levelMakerItemCustomizationMenu; //Field offset: 0x20
	[SerializeField]
	private GameObject _view; //Field offset: 0x28
	[SerializeField]
	private ScrollRect _itemsScrollRect; //Field offset: 0x30
	[SerializeField]
	private PalettePreviewCustomizationUIItem __palettePreviewPrefab; //Field offset: 0x38
	private List<PalettePreviewCustomizationUIItem> _palettePreviewUIItems; //Field offset: 0x40
	private UIItemPool<PalettePreviewCustomizationUIItem> _palettePreviewUIItemsPool; //Field offset: 0x48
	private PalettePreviewCustomizationUIItem _lastPreviewItem; //Field offset: 0x50

	public LevelMakerItemAllPalettesMenu() { }

	private void Awake() { }

	private List<LevelMakerCCGroup> GetMaterialGroups(string materialGroupName) { }

	private string GetPackDetails(string configName, out string packName) { }

	public void Hide() { }

	private void Init() { }

	private bool IsVisible() { }

	private void OnDestroy() { }

	private void OnPaletteButtonClick() { }

	private void Show(bool forceOpen = true) { }

	public void ShowItemsInCategory(PalettePreviewCustomizationUIItem previewItem, LevelMakerCCBase[] configs, LevelMakerCustomizationObjectHandlerBase objectHandler, string category) { }

	private bool TryGetMaterialGroupName(string configName, out string materialGroupName) { }

}

