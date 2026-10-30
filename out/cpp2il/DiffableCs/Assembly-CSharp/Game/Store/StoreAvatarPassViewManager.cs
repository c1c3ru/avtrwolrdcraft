namespace Game.Store;

public class StoreAvatarPassViewManager : StoreViewManagerBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<Group> <>9__14_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <Init>b__14_0(Group x) { }

	}

	[CompilerGenerated]
	private static StoreAvatarPassViewManager <Instance>k__BackingField; //Field offset: 0x0
	[SerializeField]
	private GameObject _normalModeParent; //Field offset: 0x60
	[SerializeField]
	private Transform _packItemsParent; //Field offset: 0x68
	[SerializeField]
	private Canvas _canvas; //Field offset: 0x70
	[SerializeField]
	private StoreAvatarPassPurchaseWindow _avatarPassWindow; //Field offset: 0x78
	[SerializeField]
	private ScrollRect _ItemsScrollRect; //Field offset: 0x80

	public private static StoreAvatarPassViewManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public StoreAvatarPassViewManager() { }

	[CompilerGenerated]
	private void <Init>b__14_1() { }

	protected virtual void Awake() { }

	[CompilerGenerated]
	public static StoreAvatarPassViewManager get_Instance() { }

	protected virtual void Init() { }

	protected virtual void OnBackButtonClickImplement() { }

	protected virtual void OnCloseWindow() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnShowWindow() { }

	[CompilerGenerated]
	private static void set_Instance(StoreAvatarPassViewManager value) { }

	public static void Show() { }

	private static void ShowImplement() { }

	public void ShowPurchaseWindow() { }

	protected virtual void ShowStoreScene() { }

}

