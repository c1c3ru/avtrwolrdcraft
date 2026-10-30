namespace PazuCore.AF.ActionBar;

public class HubResumeGameBanner : ButtonBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public int localId; //Field offset: 0x10

		public <>c__DisplayClass13_0() { }

		internal bool <Init>b__0(Game x) { }

	}

	[SerializeField]
	private Image _icon; //Field offset: 0x20
	private TextureComponent _textureComponent; //Field offset: 0x28
	private CardsModel _cardsModel; //Field offset: 0x30
	private int _localId; //Field offset: 0x38
	private int _bunnerPosition; //Field offset: 0x3C
	private bool _isDefaultCard; //Field offset: 0x40
	private HubResumeBannersController _controller; //Field offset: 0x48
	private string _imageUrl; //Field offset: 0x50

	public HubResumeGameBanner() { }

	[CompilerGenerated]
	private bool <OnClick>b__14_0(Game x) { }

	public void Init(CardsModel cardsModel, int localId, int bunnerPosition) { }

	public void InitDefault() { }

	protected virtual void OnClick() { }

	private void OnDisable() { }

	private void OnEnable() { }

	public void SetController(HubResumeBannersController controller) { }

	private void Start() { }

}

