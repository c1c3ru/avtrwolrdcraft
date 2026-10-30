namespace PWC.AvatarMaker;

public class AvatarMakerMultiColorsPanelItem : ButtonBase
{
	[SerializeField]
	private GameObject _selectedIndicator; //Field offset: 0x20
	[SerializeField]
	private Image _colorImage; //Field offset: 0x28
	private AvatarMakerMultiColorsPanel _panel; //Field offset: 0x30
	private int _colorIndex; //Field offset: 0x38

	public int ColorIndex
	{
		 get { } //Length: 8
	}

	public AvatarMakerMultiColorsPanelItem() { }

	public int get_ColorIndex() { }

	public void Init(AvatarMakerMultiColorsPanel panel, int colorIndex) { }

	protected virtual void OnClick() { }

	public void OnDeselected() { }

	public void OnSelected() { }

	public void SetColor(Color color) { }

}

