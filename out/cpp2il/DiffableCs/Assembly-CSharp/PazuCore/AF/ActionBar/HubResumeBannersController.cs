namespace PazuCore.AF.ActionBar;

public class HubResumeBannersController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public string op; //Field offset: 0x10
		public HubResumeBannersController <>4__this; //Field offset: 0x18

		public <>c__DisplayClass8_0() { }

		internal void <Start>b__0(string responseText) { }

	}

	[SerializeField]
	private HubResumeGameBanner[] _banners; //Field offset: 0x20
	[SerializeField]
	private Sprite _downloadSprite; //Field offset: 0x28
	[SerializeField]
	private Sprite _playSprite; //Field offset: 0x30
	private bool _isInitedDefault; //Field offset: 0x38

	public Sprite DownloadSprite
	{
		 get { } //Length: 8
	}

	public Sprite PlaySprite
	{
		 get { } //Length: 8
	}

	public HubResumeBannersController() { }

	private void ClearBanners(int exclude) { }

	public Sprite get_DownloadSprite() { }

	public Sprite get_PlaySprite() { }

	public void Init(List<CardsModel> cardsModels) { }

	private void InitBanners(CardsModel cardsModel, HubResumeGameBanner banner, int index) { }

	public void InitDefault(int index) { }

	private void Start() { }

}

