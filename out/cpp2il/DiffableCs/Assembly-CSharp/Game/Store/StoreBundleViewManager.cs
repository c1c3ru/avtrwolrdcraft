namespace Game.Store;

public class StoreBundleViewManager : StoreViewManagerBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<Item> <>9__19_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <Init>b__19_0(Item x) { }

	}

	private static string _bundleNameDataToUseOnNextLoad; //Field offset: 0x0
	[CompilerGenerated]
	private static StoreBundleViewManager <Instance>k__BackingField; //Field offset: 0x8
	[SerializeField]
	private GameObject _normalModeParent; //Field offset: 0x60
	[SerializeField]
	private Transform _bundleItemParent; //Field offset: 0x68
	[SerializeField]
	private Transform _packItemsParent; //Field offset: 0x70
	[SerializeField]
	private Canvas _canvas; //Field offset: 0x78
	[SerializeField]
	private ScrollRect _ItemsScrollRect; //Field offset: 0x80
	private Item _bundleItemData; //Field offset: 0x88
	private int _bundleStoreIndex; //Field offset: 0x90

	public private static StoreBundleViewManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public StoreBundleViewManager() { }

	[CompilerGenerated]
	private void <Init>b__19_1() { }

	protected virtual void Awake() { }

	[CompilerGenerated]
	public static StoreBundleViewManager get_Instance() { }

	protected virtual void Init() { }

	protected virtual void OnBackButtonClickImplement() { }

	protected virtual void OnCloseWindow() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnShowWindow() { }

	public void ReloadCurrentView() { }

	[CompilerGenerated]
	private static void set_Instance(StoreBundleViewManager value) { }

	public static void Show(int itemIndex) { }

	public static void Show(string bundlePackName) { }

	private static void ShowImplement() { }

	protected virtual void ShowStoreScene() { }

}

