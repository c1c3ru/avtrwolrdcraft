namespace PWC.AvatarMaker;

public class AvatarMakerMultiColorsPanel : MonoBehaviour
{
	[SerializeField]
	private GameObject _view; //Field offset: 0x20
	[SerializeField]
	private AvatarMakerMultiColorsPanelItem[] _items; //Field offset: 0x28
	private AvatarMakerMultiColorsPanelItem _currentSelectedItem; //Field offset: 0x30

	public AvatarMakerMultiColorsPanel() { }

	private void Awake() { }

	public float GetHeight() { }

	public int GetSelectedColorIndex() { }

	public void HidePanel() { }

	private void OnColorThumbClick(ColorButtonConfig colorButtonConfig) { }

	private void OnDestroy() { }

	public void OnItemClick(AvatarMakerMultiColorsPanelItem item) { }

	public void SetColors(Color[] colors) { }

	public void ShowPanel(int colorsCount) { }

}

