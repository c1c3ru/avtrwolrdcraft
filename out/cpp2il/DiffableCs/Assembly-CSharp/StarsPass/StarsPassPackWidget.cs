namespace StarsPass;

public class StarsPassPackWidget : MonoBehaviour
{
	private static StarsPassPackWidget currentClickedWidget; //Field offset: 0x0
	private const string WIDGET_STATIC_ANIM = "Static"; //Field offset: 0x0
	private const string WIDGET_GLOW_LOOP_ANIM = "Glow_Loop"; //Field offset: 0x0
	private const string WIDGET_PRIZE_CLAIM_ANIM = "Prize_Claim"; //Field offset: 0x0
	[SerializeField]
	private StarsPassViewManager _starsPassViewManager; //Field offset: 0x20
	[SerializeField]
	private Image _packWidgetImage; //Field offset: 0x28
	[SerializeField]
	private SkeletonGraphic _skeletonGraphic; //Field offset: 0x30
	[SerializeField]
	private GameObject _seeMoreButton; //Field offset: 0x38
	[SerializeField]
	private Button _widgetButton; //Field offset: 0x40
	private int _packIndex; //Field offset: 0x48
	[CompilerGenerated]
	private Action<Int32> OnPackSeeMoreAction; //Field offset: 0x50

	public event Action<Int32> OnPackSeeMoreAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public int PackIndex
	{
		 get { } //Length: 8
	}

	public Image PackWidgetImage
	{
		 get { } //Length: 8
	}

	public StarsPassPackWidget() { }

	[CompilerGenerated]
	private void <DisableChoose>b__21_0(float value) { }

	[CompilerGenerated]
	private void <OnPackSelected>b__18_0(float value) { }

	[CompilerGenerated]
	private void <PlayPackClaimAnimation>b__20_0() { }

	[CompilerGenerated]
	public void add_OnPackSeeMoreAction(Action<Int32> value) { }

	public void DisableChoose() { }

	public int get_PackIndex() { }

	public Image get_PackWidgetImage() { }

	private void OnDestroy() { }

	public void OnPackSelected() { }

	public void PlayPackClaimAnimation() { }

	[CompilerGenerated]
	public void remove_OnPackSeeMoreAction(Action<Int32> value) { }

	public void ResetToSelectable() { }

	public void SeeMorePackDetail() { }

	public void SetPackIndex(int packIndex) { }

	public void SetWidget(Sprite widgetSprite) { }

	public void ToggleButtons(bool value) { }

}

