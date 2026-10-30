namespace PWC.LevelPhone;

public class VehicleContent : ApplicationContentBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<VehiclePage> <>9__40_0; //Field offset: 0x8
		public static Action<VehiclePage> <>9__43_0; //Field offset: 0x10
		public static Predicate<List`1<Int32>> <>9__50_0; //Field offset: 0x18
		public static Action<VehiclePage> <>9__56_0; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal void <GetIDs>b__43_0(VehiclePage page) { }

		internal bool <HasMoreThanOnePage>b__50_0(List<Int32> x) { }

		internal void <OnSetActive>b__40_0(VehiclePage page) { }

		internal void <SelectCategory>b__56_0(VehiclePage page) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass41_0
	{
		public bool value; //Field offset: 0x10

		public <>c__DisplayClass41_0() { }

		internal void <OnPhoneEndAnimation>b__0(VehiclePage page) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass42_0
	{
		public ContactsAppPageSwipeType pageSwipeType; //Field offset: 0x10

		public <>c__DisplayClass42_0() { }

		internal void <OnVehiclesPageSwipe>b__0(VehiclePage page) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass51_0
	{
		public bool showArrows; //Field offset: 0x10
		public VehicleContent <>4__this; //Field offset: 0x18

		public <>c__DisplayClass51_0() { }

		internal void <SyncArrows>b__0(ContactsArrow arrow) { }

		internal void <SyncArrows>b__1(ContactsArrow arrow) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass53_0
	{
		public bool value; //Field offset: 0x10
		public VehicleContent <>4__this; //Field offset: 0x18

		public <>c__DisplayClass53_0() { }

		internal void <OnApplicationEndAnimation>b__0(VehiclePage page) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass54_0
	{
		public VehicleData vehicleData; //Field offset: 0x10

		public <>c__DisplayClass54_0() { }

		internal bool <OnVehicleThumbClick>b__0(LevelPlayerVehicle x) { }

	}

	[CompilerGenerated]
	private sealed class <Start>d__38 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public VehicleContent <>4__this; //Field offset: 0x20
		private int <i>5__2; //Field offset: 0x28

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
		public <Start>d__38(int <>1__state) { }

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

	public const float ANIMATION_TIME = 0,1; //Field offset: 0x0
	public const int MAX_SLOTS_PER_PAGE = 3; //Field offset: 0x0
	public const int MAX_CARS_PER_PAGE = 2; //Field offset: 0x0
	private const string CAR_RETURN_SOUND = "Car_Return"; //Field offset: 0x0
	private const string CAR_ORDER_SOUND = "Car_Order"; //Field offset: 0x0
	[CompilerGenerated]
	private int <CurrentPageIndex>k__BackingField; //Field offset: 0x34
	[CompilerGenerated]
	private bool <IsAnimatedSeparatorOnce>k__BackingField; //Field offset: 0x38
	[SerializeField]
	private VehicleThumb _vehiclePrefab; //Field offset: 0x40
	[SerializeField]
	private List<VehiclePage> _pages; //Field offset: 0x48
	[SerializeField]
	private List<ContactsArrow> _arrows; //Field offset: 0x50
	[SerializeField]
	private GeneralVehicleData _generalVehicleData; //Field offset: 0x58
	[SerializeField]
	private List<VehiclesCategoryButton> _categoryButtons; //Field offset: 0x60
	private bool _didSetupFirstTimeInScene; //Field offset: 0x68
	private List<List`1<Int32>> _vehicleIDsPerPage; //Field offset: 0x70
	private Dictionary<Int32, Boolean> _storeItemGuids; //Field offset: 0x78
	[CompilerGenerated]
	private bool <IsSelectingCategory>k__BackingField; //Field offset: 0x80
	[CompilerGenerated]
	private VehiclesCategoryButton <SelectedVehiclesCategoryButton>k__BackingField; //Field offset: 0x88
	private VehiclesCategoryType _currentCategoryType; //Field offset: 0x90

	public private int CurrentPageIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public bool IsAnimatedSeparatorOnce
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public bool IsMakerCategory
	{
		 get { } //Length: 16
	}

	public private bool IsSelectingCategory
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private VehiclesCategoryButton SelectedVehiclesCategoryButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public bool ShowsAddCarButton
	{
		 get { } //Length: 16
	}

	public VehicleThumb VehiclePrefab
	{
		 get { } //Length: 8
	}

	public VehicleContent() { }

	[CompilerGenerated]
	private void <GetIDs>b__43_1(VehiclePage page) { }

	protected virtual void Awake() { }

	private void ChunkIntoPages(List<Int32> ids) { }

	public void DownArrow() { }

	[CompilerGenerated]
	public int get_CurrentPageIndex() { }

	[CompilerGenerated]
	public bool get_IsAnimatedSeparatorOnce() { }

	public bool get_IsMakerCategory() { }

	[CompilerGenerated]
	public bool get_IsSelectingCategory() { }

	[CompilerGenerated]
	public VehiclesCategoryButton get_SelectedVehiclesCategoryButton() { }

	public bool get_ShowsAddCarButton() { }

	public VehicleThumb get_VehiclePrefab() { }

	public GeneralVehicleData GetAllVehiclesData() { }

	private List<Int32> GetAuthoredVehicleIDs(bool wantEarned) { }

	private void GetIDs() { }

	private List<Int32> GetIDsForCategory(VehiclesCategoryType categoryType) { }

	private List<Int32> GetIDsForCurrentCategory() { }

	private List<Int32> GetPhonePremadeCarIDs() { }

	private List<Int32> GetSavedCarIDs() { }

	public List<Int32> GetVehiclesForCurrentPageIndex() { }

	private bool HasMoreThanOnePage() { }

	public bool IsCarID(int id) { }

	protected virtual void OnApplicationEndAnimation(bool value) { }

	protected virtual void OnBackButtonClick() { }

	private void OnCarThumbClick(int carId) { }

	public void OnCompleteSwipeAnimation() { }

	protected virtual void OnDestroy() { }

	private void OnPhoneEndAnimation(bool value) { }

	protected virtual void OnSetActive(bool value) { }

	private void OnVehiclesPageSwipe(ContactsAppPageSwipeType pageSwipeType) { }

	private void OnVehicleThumbClick(VehicleData vehicleData) { }

	public void SelectCategory(VehiclesCategoryButton button) { }

	[CompilerGenerated]
	private void set_CurrentPageIndex(int value) { }

	[CompilerGenerated]
	public void set_IsAnimatedSeparatorOnce(bool value) { }

	[CompilerGenerated]
	private void set_IsSelectingCategory(bool value) { }

	[CompilerGenerated]
	private void set_SelectedVehiclesCategoryButton(VehiclesCategoryButton value) { }

	private void SetVehicleCategory() { }

	[IteratorStateMachine(typeof(<Start>d__38))]
	private IEnumerator Start() { }

	private void SyncArrows() { }

	private void SyncCategoryButtons() { }

	public void UpArrow() { }

}

