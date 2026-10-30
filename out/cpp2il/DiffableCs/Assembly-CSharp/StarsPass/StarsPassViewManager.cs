namespace StarsPass;

public class StarsPassViewManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass40_0
	{
		public PacksWidgetsAnimator packsWidgetsAnimator; //Field offset: 0x10

		public <>c__DisplayClass40_0() { }

		internal void <TriggerMilestoneUnlock>b__0() { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass44_0
	{
		public int milestoneIndex; //Field offset: 0x0
		public StarsPassViewManager <>4__this; //Field offset: 0x8
		public GameObject packItemPrefab; //Field offset: 0x10
		public MilestoneStatus packState; //Field offset: 0x18
		public Int32[] packsIndexes; //Field offset: 0x20

	}

	[CompilerGenerated]
	private sealed class <FinalizeInitCoroutine>d__38 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public StarsPassViewManager <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <FinalizeInitCoroutine>d__38(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <Start>d__36 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public StarsPassViewManager <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <Start>d__36(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private static StarsPassViewManager <Instance>k__BackingField; //Field offset: 0x0
	private const float INITIAL_SCROLL_OFFSET = 250; //Field offset: 0x0
	private const string BOX_BOUNCE_ANIM = "Box_Bounce"; //Field offset: 0x0
	private const string BOX_STATIC_ANIM = "Box_Static"; //Field offset: 0x0
	private const float LOADING_SCREEN_MAX_DURATION = 10; //Field offset: 0x0
	private static readonly Dictionary<String, Sprite> _widgetSpriteCache; //Field offset: 0x8
	[SerializeField]
	private StarsPassBarManager _starsBarManager; //Field offset: 0x20
	[SerializeField]
	private StarsPassLongBar _starsPassLongBar; //Field offset: 0x28
	[SerializeField]
	private StorePazuCurrencyViewer _storePazuCurrencyViewer; //Field offset: 0x30
	[SerializeField]
	private StarsPassCurrencyViewerAnimator _starsPassCurrencyViewerAnimator; //Field offset: 0x38
	[SerializeField]
	private StarsPassPacksWidgetsPanel _starsPassPacksWidgetsPanel; //Field offset: 0x40
	[SerializeField]
	private ScrollRect _scrollRect; //Field offset: 0x48
	[SerializeField]
	private RectTransform _mainHorizontalContent; //Field offset: 0x50
	[SerializeField]
	private Transform _packsContentTransform; //Field offset: 0x58
	[SerializeField]
	private SkeletonGraphic _boxSkeletonGraphic; //Field offset: 0x60
	[SerializeField]
	private GameObject _packsPackPrefab; //Field offset: 0x68
	[SerializeField]
	private GameObject _currencyPackPrefab; //Field offset: 0x70
	[SerializeField]
	private SuperStarCompletionPassPanel _superStarPanel; //Field offset: 0x78
	[SerializeField]
	private LoadingScreenScreen _loadingScreenPrefab; //Field offset: 0x80
	private List<StarsPassPackItem> _storePackItemsList; //Field offset: 0x88
	private LoadingScreenScreen _loadingScreen; //Field offset: 0x90
	private readonly List<StarsPassCurrencyPackItem> _pendingCurrencyAutoClaims; //Field offset: 0x98
	private int _totalMilestonesIndex; //Field offset: 0xA0

	public private static StarsPassViewManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 104
	}

	public StarsPassBarManager StarsBarManager
	{
		 get { } //Length: 8
	}

	public StarsPassPacksWidgetsPanel StarsPassPacksWidgetsPanel
	{
		 get { } //Length: 8
	}

	public SuperStarCompletionPassPanel SuperStarPanel
	{
		 get { } //Length: 8
	}

	private static StarsPassViewManager() { }

	public StarsPassViewManager() { }

	[CompilerGenerated]
	private void <PlayBoxSpineAnimation>b__47_0() { }

	[CompilerGenerated]
	private void <PlayBoxSpineAnimation>b__47_1() { }

	[CompilerGenerated]
	private void <SpawnPack>g__ConfigureCarouselPacksItem|44_0(StarsPassCarouselPackItem starsPassCarouselPackItem, ref <>c__DisplayClass44_0 unnamed_param_1) { }

	public void AnimateCurrencyViewer(bool moveDown) { }

	private void AutoClaimReachedCurrencyGifts() { }

	private void Awake() { }

	private void CancelLoadingScreenAutoHide() { }

	public void DisableLockedPackAnimation(int milestoneIndex) { }

	[IteratorStateMachine(typeof(<FinalizeInitCoroutine>d__38))]
	private IEnumerator FinalizeInitCoroutine() { }

	private void FocusStoreOnCurrencyPacks() { }

	[CompilerGenerated]
	public static StarsPassViewManager get_Instance() { }

	public StarsPassBarManager get_StarsBarManager() { }

	public StarsPassPacksWidgetsPanel get_StarsPassPacksWidgetsPanel() { }

	public SuperStarCompletionPassPanel get_SuperStarPanel() { }

	private int GetFirstItemIndexInGroup(StoreData storeData, Group group) { }

	public int GetMilestonesNumber() { }

	public List<StarsPassPackItem> GetStarsPassPackItemList() { }

	private void HideLoadingScreen() { }

	public void Init() { }

	private static Sprite LoadWidgetSprite(string widgetName) { }

	public void MoveScrollToLongBarFill(float fillAmount) { }

	public bool OnAndroidBack() { }

	public void OnBackButtonPressed() { }

	private void OnDestroy() { }

	private void PlayBoxSpineAnimation(float minTimeValue, float maxTimeValue) { }

	private void PlayBoxStaticAnimation() { }

	[CompilerGenerated]
	private static void set_Instance(StarsPassViewManager value) { }

	private void ShowLoadingScreen() { }

	private void SpawnPack(Int32[] packsIndexes, int currencyAmount, MilestoneStatus packState, int milestoneIndex) { }

	private void SpawnPacksPrefabs() { }

	[IteratorStateMachine(typeof(<Start>d__36))]
	private IEnumerator Start() { }

	public void TriggerMilestoneUnlock(int milestoneIndex) { }

	private static bool TryGetTransitionLoadingScreen(out LoadingScreenScreen loadingScreen) { }

}

