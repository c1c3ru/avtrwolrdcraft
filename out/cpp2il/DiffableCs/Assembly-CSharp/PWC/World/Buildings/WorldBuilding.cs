namespace PWC.World.Buildings;

public class WorldBuilding : WorldEnterableEntity, IWorldResettable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<SceneObjectData, String> <>9__27_0; //Field offset: 0x8
		public static Func<SceneObjectData, String> <>9__27_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal string <ResetTransportation>b__27_0(SceneObjectData x) { }

		internal string <ResetTransportation>b__27_1(SceneObjectData x) { }

	}

	[CompilerGenerated]
	private sealed class <Start>d__23 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public WorldBuilding <>4__this; //Field offset: 0x20

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
		public <Start>d__23(int <>1__state) { }

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

	public static readonly List<WorldBuilding> All; //Field offset: 0x0
	[SerializeField]
	private GameObject _view; //Field offset: 0x40
	[SerializeField]
	private WorldBuildingType _buildingType; //Field offset: 0x48
	[SerializeField]
	private LevelType _defaultLevelType; //Field offset: 0x4C
	[SerializeField]
	private LevelType[] _moreValidLevelTypes; //Field offset: 0x50
	[SerializeField]
	private bool _isFree; //Field offset: 0x58
	[SerializeField]
	private GameObject _lock; //Field offset: 0x60
	[SerializeField]
	private Vector2 _resetButtonOffset; //Field offset: 0x68
	private bool _isFreeFromRemoteConfig; //Field offset: 0x70
	private readonly HashSet<String> _multiplayer_sceneNames; //Field offset: 0x78
	private HashSet<String> _resettableLevels; //Field offset: 0x80
	[CompilerGenerated]
	private Action<WorldBuilding, LevelType> OnClickBuildingAction; //Field offset: 0x88
	public UnityEvent OnClickAction; //Field offset: 0x90
	private TransportationResetData _transportationResetData; //Field offset: 0x98

	public event Action<WorldBuilding, LevelType> OnClickBuildingAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LevelType DefaultLevelType
	{
		 get { } //Length: 8
	}

	public LevelType[] MoreValidLevelTypes
	{
		 get { } //Length: 8
	}

	public WorldBuildingType WorldBuildingType
	{
		 get { } //Length: 8
	}

	private static WorldBuilding() { }

	public WorldBuilding() { }

	[CompilerGenerated]
	private void <PlayIdleTweens>b__32_0() { }

	[CompilerGenerated]
	private void <PlayIdleTweens>b__32_1() { }

	[CompilerGenerated]
	public void add_OnClickBuildingAction(Action<WorldBuilding, LevelType> value) { }

	private void AddResetLevelsButtons() { }

	protected virtual void Awake() { }

	public void ClickOnLevel(LevelType levelType) { }

	private void EnsureResettableLevels() { }

	public LevelType get_DefaultLevelType() { }

	public LevelType[] get_MoreValidLevelTypes() { }

	public WorldBuildingType get_WorldBuildingType() { }

	private bool HasResettableLevels() { }

	private bool IsCurrentlyFree() { }

	public bool Multiplayer_ContainsScene(string sceneName) { }

	protected virtual void OnDestroy() { }

	private void OnGameUnlockedValueChange(bool isGameUnlocked) { }

	protected virtual void OnPointerClickInternal() { }

	private void OnWorldPostInit() { }

	private void PlayIdleTweens() { }

	[CompilerGenerated]
	public void remove_OnClickBuildingAction(Action<WorldBuilding, LevelType> value) { }

	public void ResetTransportation() { }

	public override void ResetWorldEntity() { }

	[IteratorStateMachine(typeof(<Start>d__23))]
	private IEnumerator Start() { }

	private void SyncRemoteConfig() { }

	private bool TryGetRemoteConfigItem(out ZoneBuildingItem remoteConfigItem) { }

}

