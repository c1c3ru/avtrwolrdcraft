namespace PWC.UGC;

public class UGCManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Action, Int32> <>9__33_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal int <CallSafeAction>b__33_0(Action action) { }

	}

	[CompilerGenerated]
	private static Action<Boolean> OnEditModeChangeAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action OnUGCPermanentPrePostInitAction; //Field offset: 0x8
	[CompilerGenerated]
	private static Action OnUGCPermanentPostInitAction; //Field offset: 0x10
	public static SafeAction<Action> OnUGCPrePostInitAction; //Field offset: 0x18
	public static SafeAction<Action> OnUGCPostInitAction; //Field offset: 0x20
	private static readonly Dictionary<Object, Int32> _initEventsCallOrder; //Field offset: 0x28
	[CompilerGenerated]
	private static UGCManager <Instance>k__BackingField; //Field offset: 0x30
	private IUGCEntity _selectedItem; //Field offset: 0x20
	[CompilerGenerated]
	private bool <IsEditMode>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private bool <IsUGCPostInit>k__BackingField; //Field offset: 0x29

	public static event Action<Boolean> OnEditModeChangeAction
	{
		[CompilerGenerated]
		 add { } //Length: 240
		[CompilerGenerated]
		 remove { } //Length: 240
	}

	public static event Action OnUGCPermanentPostInitAction
	{
		[CompilerGenerated]
		 add { } //Length: 220
		[CompilerGenerated]
		 remove { } //Length: 220
	}

	public static event Action OnUGCPermanentPrePostInitAction
	{
		[CompilerGenerated]
		 add { } //Length: 220
		[CompilerGenerated]
		 remove { } //Length: 220
	}

	public private static UGCManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 96
	}

	public private bool IsEditMode
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private bool IsUGCPostInit
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public IUGCEntity SelectedItem
	{
		 get { } //Length: 8
	}

	private static UGCManager() { }

	public UGCManager() { }

	[CompilerGenerated]
	public static void add_OnEditModeChangeAction(Action<Boolean> value) { }

	[CompilerGenerated]
	public static void add_OnUGCPermanentPostInitAction(Action value) { }

	[CompilerGenerated]
	public static void add_OnUGCPermanentPrePostInitAction(Action value) { }

	private void Awake() { }

	private void CallSafeAction(SafeAction<Action> action, bool sortByOrder = true) { }

	[CompilerGenerated]
	public static UGCManager get_Instance() { }

	[CompilerGenerated]
	public bool get_IsEditMode() { }

	[CompilerGenerated]
	public bool get_IsUGCPostInit() { }

	public IUGCEntity get_SelectedItem() { }

	public void Init() { }

	public static bool IsUGCManagerPostInit() { }

	private void OnDestroy() { }

	private void OnItemPreDestroyUGCEntity(UGCItemBase item) { }

	[CompilerGenerated]
	public static void remove_OnEditModeChangeAction(Action<Boolean> value) { }

	[CompilerGenerated]
	public static void remove_OnUGCPermanentPostInitAction(Action value) { }

	[CompilerGenerated]
	public static void remove_OnUGCPermanentPrePostInitAction(Action value) { }

	[CompilerGenerated]
	private static void set_Instance(UGCManager value) { }

	[CompilerGenerated]
	private void set_IsEditMode(bool value) { }

	[CompilerGenerated]
	private void set_IsUGCPostInit(bool value) { }

	public void SetEditMode(bool isEditMode) { }

	public static void SetInitEventsOrder(object obj, int order) { }

	public void SetSelectedItem(IUGCEntity item) { }

	public void ToggleEditMode() { }

	public SpawnResultType TrySpawnItem(IUGCSpawnableFromUI prefab, out IUGCEntity instance) { }

}

