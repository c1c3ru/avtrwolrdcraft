namespace StarsPass;

public class StarsPassPacksWidgetsPanel : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass15_0
	{
		public bool isLastGift; //Field offset: 0x10
		public StarsPassPacksWidgetsPanel <>4__this; //Field offset: 0x18
		public StarsPassCarouselPackItem starsPassCarouselPackItem; //Field offset: 0x20
		public int chosenPackIndex; //Field offset: 0x28

		public <>c__DisplayClass15_0() { }

		internal void <BeginPackClaimSequence>b__0() { }

		internal void <BeginPackClaimSequence>g__CompleteClaim|1() { }

	}

	[SerializeField]
	private StarsPassPackWidget[] _starsPassPackWidgetArray; //Field offset: 0x20
	[SerializeField]
	private GameObject _panelWindow; //Field offset: 0x28
	[SerializeField]
	private GameObject _claimButtonObject; //Field offset: 0x30
	[SerializeField]
	private GameObject _exitButtonObject; //Field offset: 0x38
	[SerializeField]
	private GameObject _confirmToolTipObject; //Field offset: 0x40
	[SerializeField]
	private float _confirmAnimDuration; //Field offset: 0x48
	private PacksWidgetsAnimator _packsWidgetsAnimator; //Field offset: 0x50
	private StarsPassPackWidget _chosenPackWidget; //Field offset: 0x58
	[CompilerGenerated]
	private Action<StarsPassCarouselPackItem, Int32> OnPackConfirmedAction; //Field offset: 0x60

	public event Action<StarsPassCarouselPackItem, Int32> OnPackConfirmedAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public StarsPassPackWidget[] StarsPassPackWidgetArray
	{
		 get { } //Length: 8
	}

	public StarsPassPacksWidgetsPanel() { }

	[CompilerGenerated]
	public void add_OnPackConfirmedAction(Action<StarsPassCarouselPackItem, Int32> value) { }

	private void BeginPackClaimSequence(StarsPassCarouselPackItem starsPassCarouselPackItem, int chosenPackIndex) { }

	private bool CanConfirmClaim() { }

	public void ClosePacksWidgetsPanel() { }

	public void DisableConfirmTooltip() { }

	private void DisablePanelUI() { }

	public void EnableConfirmTooltip() { }

	public StarsPassPackWidget[] get_StarsPassPackWidgetArray() { }

	public void OnClickPackWidget(StarsPassPackWidget packWidget) { }

	public void OnConfirmClaimButtonClick() { }

	public void OpenPacksWidgetsPanel(PacksWidgetsAnimator packsSwapperAnim) { }

	[CompilerGenerated]
	public void remove_OnPackConfirmedAction(Action<StarsPassCarouselPackItem, Int32> value) { }

	public void ShowClaimButton() { }

	private void ToggleWidgetsButtons(bool value) { }

}

