namespace PWC.Level;

public class LevelManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__40_0; //Field offset: 0x8
		public static Func<Action, Int32> <>9__42_0; //Field offset: 0x10
		public static Predicate<LevelCharacter> <>9__46_2; //Field offset: 0x18
		public static Action <>9__46_0; //Field offset: 0x20
		public static Predicate<LevelItem> <>9__46_3; //Field offset: 0x28
		public static Action <>9__46_1; //Field offset: 0x30

		private static <>c() { }

		public <>c() { }

		internal int <CallSafeAction>b__42_0(Action action) { }

		internal void <Init>b__40_0() { }

		internal void <OnPrefabRuntimeSpawn>b__46_0() { }

		internal void <OnPrefabRuntimeSpawn>b__46_1() { }

		internal bool <OnPrefabRuntimeSpawn>b__46_2(LevelCharacter x) { }

		internal bool <OnPrefabRuntimeSpawn>b__46_3(LevelItem item) { }

	}

	[CompilerGenerated]
	private sealed class <Start>d__38 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelManager <>4__this; //Field offset: 0x20

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

	private const int MAX_CHARACTERS = 50; //Field offset: 0x0
	private const int MAX_ITEMS = 2500; //Field offset: 0x0
	public static SafeAction<Action> OnPreInitAction; //Field offset: 0x0
	public static SafeAction<Action> OnPrePostInitAction; //Field offset: 0x8
	public static SafeAction<Action> OnPostInitAction; //Field offset: 0x10
	[CompilerGenerated]
	private static Action OnPermanentPrePostInitAction; //Field offset: 0x18
	[CompilerGenerated]
	private static Action OnPermanentPostInitAction; //Field offset: 0x20
	private static readonly Dictionary<Object, Int32> _initEventsCallOrder; //Field offset: 0x28
	[CompilerGenerated]
	private static LevelManager <Instance>k__BackingField; //Field offset: 0x30
	[SerializeField]
	private LevelCamera _levelCamera; //Field offset: 0x20
	[SerializeField]
	private Phone _phone; //Field offset: 0x28
	[SerializeField]
	private BackgroundPlanet _backgroundPlanet; //Field offset: 0x30
	[CompilerGenerated]
	private bool <IsPostLoadPersistentData>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private bool <IsPostInit>k__BackingField; //Field offset: 0x39
	[CompilerGenerated]
	private bool <IsAboutToLoadScene>k__BackingField; //Field offset: 0x3A
	[CompilerGenerated]
	private bool <Multiplayer_IsLoadingLevelWithOtherPlayers>k__BackingField; //Field offset: 0x3B

	public static event Action OnPermanentPostInitAction
	{
		[CompilerGenerated]
		 add { } //Length: 220
		[CompilerGenerated]
		 remove { } //Length: 220
	}

	public static event Action OnPermanentPrePostInitAction
	{
		[CompilerGenerated]
		 add { } //Length: 220
		[CompilerGenerated]
		 remove { } //Length: 220
	}

	public private static LevelManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 96
	}

	public private bool IsAboutToLoadScene
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private bool IsPostInit
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private bool IsPostLoadPersistentData
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public bool Multiplayer_IsLoadingLevelWithOtherPlayers
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public Phone Phone
	{
		 get { } //Length: 8
	}

	private static LevelManager() { }

	public LevelManager() { }

	[CompilerGenerated]
	public static void add_OnPermanentPostInitAction(Action value) { }

	[CompilerGenerated]
	public static void add_OnPermanentPrePostInitAction(Action value) { }

	private void Awake() { }

	private void CallSafeAction(SafeAction<Action> action, bool sortByOrder = true) { }

	public void EnsrureDefaultSceneGameObjectsInitiated() { }

	[CompilerGenerated]
	public static LevelManager get_Instance() { }

	[CompilerGenerated]
	public bool get_IsAboutToLoadScene() { }

	[CompilerGenerated]
	public bool get_IsPostInit() { }

	[CompilerGenerated]
	public bool get_IsPostLoadPersistentData() { }

	[CompilerGenerated]
	public bool get_Multiplayer_IsLoadingLevelWithOtherPlayers() { }

	public Phone get_Phone() { }

	public List<Int32> GetAllLevelDefaultAvatarsID() { }

	private void Init() { }

	private void InitPhone() { }

	public static bool IsManagerPostInit() { }

	public static bool IsManagerPostLoadPersistentData() { }

	private void OnBeforeSceneLoadStage2() { }

	private void OnBeforeSceneLoadStage3() { }

	private void OnDestroy() { }

	private void OnPhoneAnimate(bool animateIn) { }

	private void OnPostSaveProgress(Scene scene) { }

	private void OnPrefabRuntimeSpawn(PDPrefab instance, bool _) { }

	private void OnSpawnObjectsFromBulkData(List<PDPrefab> instances) { }

	[CompilerGenerated]
	public static void remove_OnPermanentPostInitAction(Action value) { }

	[CompilerGenerated]
	public static void remove_OnPermanentPrePostInitAction(Action value) { }

	private void RestoreMakerExcludedSkinClothingIfNeeded() { }

	[CompilerGenerated]
	private static void set_Instance(LevelManager value) { }

	[CompilerGenerated]
	private void set_IsAboutToLoadScene(bool value) { }

	[CompilerGenerated]
	private void set_IsPostInit(bool value) { }

	[CompilerGenerated]
	private void set_IsPostLoadPersistentData(bool value) { }

	[CompilerGenerated]
	public void set_Multiplayer_IsLoadingLevelWithOtherPlayers(bool value) { }

	public static void SetInitEventsOrder(object obj, int order) { }

	[IteratorStateMachine(typeof(<Start>d__38))]
	private IEnumerator Start() { }

}

