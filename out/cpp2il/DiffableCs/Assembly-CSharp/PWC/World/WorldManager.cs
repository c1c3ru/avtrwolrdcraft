namespace PWC.World;

public class WorldManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <Start>d__27 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public WorldManager <>4__this; //Field offset: 0x20

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
		public <Start>d__27(int <>1__state) { }

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

	public const string SAVED_SCENE_FOLDER_NAME = "World"; //Field offset: 0x0
	[CompilerGenerated]
	private static Action OnPostInitAction; //Field offset: 0x0
	[CompilerGenerated]
	private static WorldManager <Instance>k__BackingField; //Field offset: 0x8
	[SerializeField]
	private WorldCamera _worldCamera; //Field offset: 0x20
	[SerializeField]
	private BackgroundPlanet _planet; //Field offset: 0x28
	[SerializeField]
	private CameraIris _iris; //Field offset: 0x30
	[SerializeField]
	private WorldCloudsSpawner _cloudsSpawner; //Field offset: 0x38
	[SerializeField]
	private List<WorldZone> _zones; //Field offset: 0x40
	[SerializeField]
	private string _BGMusicName; //Field offset: 0x48
	[SerializeField]
	private string _ugcBGMusicName; //Field offset: 0x50
	[CompilerGenerated]
	private bool <IsPostInit>k__BackingField; //Field offset: 0x58
	[CompilerGenerated]
	private bool <IsGameUnlocked>k__BackingField; //Field offset: 0x59
	[CompilerGenerated]
	private Action<Boolean> OnGameUnlockedValueChangeAction; //Field offset: 0x60

	public event Action<Boolean> OnGameUnlockedValueChangeAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public static event Action OnPostInitAction
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public private static WorldManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public private bool IsGameUnlocked
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

	public WorldManager() { }

	[CompilerGenerated]
	internal static void <PlayBackGroundMusic>g__SwitchBGMusics|36_0(string switchToMusic) { }

	[CompilerGenerated]
	public void add_OnGameUnlockedValueChangeAction(Action<Boolean> value) { }

	[CompilerGenerated]
	public static void add_OnPostInitAction(Action value) { }

	public void AvatarMakerButtonPress() { }

	private void Awake() { }

	[CompilerGenerated]
	public static WorldManager get_Instance() { }

	[CompilerGenerated]
	public bool get_IsGameUnlocked() { }

	[CompilerGenerated]
	public bool get_IsPostInit() { }

	private void Init() { }

	private void InitCamera() { }

	public static bool IsManagerPostInit() { }

	private void Multiplayer_AddPanel() { }

	private void OnDestroy() { }

	private void OnUGCEditModeChange(bool isTrue) { }

	private void OnUserSync(SyncType syncType) { }

	private string OverrideGetFolderName() { }

	public void PlayBackGroundMusic(bool isUGCBGMusic) { }

	[CompilerGenerated]
	public void remove_OnGameUnlockedValueChangeAction(Action<Boolean> value) { }

	[CompilerGenerated]
	public static void remove_OnPostInitAction(Action value) { }

	[CompilerGenerated]
	private static void set_Instance(WorldManager value) { }

	[CompilerGenerated]
	private void set_IsGameUnlocked(bool value) { }

	[CompilerGenerated]
	private void set_IsPostInit(bool value) { }

	[IteratorStateMachine(typeof(<Start>d__27))]
	private IEnumerator Start() { }

}

