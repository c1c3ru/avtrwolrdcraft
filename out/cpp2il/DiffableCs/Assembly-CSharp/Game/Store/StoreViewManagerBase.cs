namespace Game.Store;

public abstract class StoreViewManagerBase : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Boolean> <>9__36_1; //Field offset: 0x8
		public static Action <>9__36_3; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal bool <ShowStoreSceneBase>b__36_1() { }

		internal void <ShowStoreSceneBase>b__36_3() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass36_0
	{
		public Action action; //Field offset: 0x10
		public Action innerAction; //Field offset: 0x18

		public <>c__DisplayClass36_0() { }

		internal void <ShowStoreSceneBase>b__0() { }

		internal void <ShowStoreSceneBase>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass38_0
	{
		public string productName; //Field offset: 0x10
		public string restoreSuccessfulMessage; //Field offset: 0x18
		public StoreViewManagerBase <>4__this; //Field offset: 0x20
		public Predicate<Item> <>9__1; //Field offset: 0x28

		public <>c__DisplayClass38_0() { }

		internal void <OnIAPEnded>b__0() { }

		internal bool <OnIAPEnded>b__1(Item x) { }

	}

	[CompilerGenerated]
	private sealed class <Start>d__33 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public StoreViewManagerBase <>4__this; //Field offset: 0x20

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
		public <Start>d__33(int <>1__state) { }

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
	private static int <FocusOnPackItemIndex>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private static int <FocusCategoryIndex>k__BackingField; //Field offset: 0x4
	[CompilerGenerated]
	private static int <FocusSubcategoryIndex>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	private static Action<StorePackItemBase> <ExtraOnFocusedItemAction>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private static StoreViewManagerBase <BaseInstance>k__BackingField; //Field offset: 0x18
	[SerializeField]
	private GameObject _backButton; //Field offset: 0x20
	[SerializeField]
	private Image _background; //Field offset: 0x28
	[SerializeField]
	private Material _normalBackgroundMaterial; //Field offset: 0x30
	[SerializeField]
	private Material _avatarPassBackgroundMaterial; //Field offset: 0x38
	[SerializeField]
	private StorePazuCurrencyViewer _pazuCurrencyViewer; //Field offset: 0x40
	[SerializeField]
	private RectTransform _packItemWindowParent; //Field offset: 0x48
	protected StoreData _storeData; //Field offset: 0x50
	[CompilerGenerated]
	private MonoBehaviour <CurrentWindow>k__BackingField; //Field offset: 0x58

	public static StoreViewManagerBase BaseInstance
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		 set { } //Length: 96
	}

	public private MonoBehaviour CurrentWindow
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public static Action<StorePackItemBase> ExtraOnFocusedItemAction
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		 set { } //Length: 96
	}

	public static int FocusCategoryIndex
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		 set { } //Length: 92
	}

	public static int FocusOnPackItemIndex
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		 set { } //Length: 92
	}

	public static int FocusSubcategoryIndex
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		 set { } //Length: 92
	}

	private static StoreViewManagerBase() { }

	protected StoreViewManagerBase() { }

	protected override void Awake() { }

	public void CloseCurrentWindowIfExists() { }

	[CompilerGenerated]
	public static StoreViewManagerBase get_BaseInstance() { }

	[CompilerGenerated]
	public MonoBehaviour get_CurrentWindow() { }

	[CompilerGenerated]
	public static Action<StorePackItemBase> get_ExtraOnFocusedItemAction() { }

	[CompilerGenerated]
	public static int get_FocusCategoryIndex() { }

	[CompilerGenerated]
	public static int get_FocusOnPackItemIndex() { }

	[CompilerGenerated]
	public static int get_FocusSubcategoryIndex() { }

	protected abstract void Init() { }

	private bool OnAndroidBack() { }

	public void OnBackButtonClick() { }

	protected override void OnBackButtonClickImplement() { }

	protected abstract void OnCloseWindow() { }

	protected override void OnDestroy() { }

	private void OnIAPEnded(IAPResult result) { }

	public void OnRestorePurchasesButtonClick() { }

	protected abstract void OnShowWindow() { }

	public void PlayMusic() { }

	[CompilerGenerated]
	protected static void set_BaseInstance(StoreViewManagerBase value) { }

	[CompilerGenerated]
	private void set_CurrentWindow(MonoBehaviour value) { }

	[CompilerGenerated]
	public static void set_ExtraOnFocusedItemAction(Action<StorePackItemBase> value) { }

	[CompilerGenerated]
	public static void set_FocusCategoryIndex(int value) { }

	[CompilerGenerated]
	public static void set_FocusOnPackItemIndex(int value) { }

	[CompilerGenerated]
	public static void set_FocusSubcategoryIndex(int value) { }

	public void SetBackgroundColors(bool isAvatarPass) { }

	public void ShowPackItemWindow(StorePackItem packItem) { }

	protected abstract void ShowStoreScene() { }

	protected static void ShowStoreSceneBase(Action action) { }

	protected void SpawnCategorySeparator(string groupKey, Transform parent, bool logIfError = true) { }

	[IteratorStateMachine(typeof(<Start>d__33))]
	private IEnumerator Start() { }

	public void StopMusic() { }

	public void SyncCurrencyText() { }

}

