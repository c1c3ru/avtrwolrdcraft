namespace PWC.Level;

public class LevelControlAllNonLevelItemLights : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<LevelLight> <>9__11_0; //Field offset: 0x8
		public static Action<LevelLight> <>9__12_0; //Field offset: 0x10
		public static Action<LevelLight> <>9__13_0; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal void <InitListIfNeeded>b__11_0(LevelLight light) { }

		internal void <SyncAllLightsOff>b__13_0(LevelLight light) { }

		internal void <SyncAllLightsOn>b__12_0(LevelLight light) { }

	}

	[CompilerGenerated]
	private static List<LevelLight> <NonLevelItemlevelLightsInScene>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private static LevelControlAllNonLevelItemLights <Instance>k__BackingField; //Field offset: 0x8
	private static bool _isOn; //Field offset: 0x10

	public private static LevelControlAllNonLevelItemLights Instance
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 96
	}

	public private static List<LevelLight> NonLevelItemlevelLightsInScene
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 104
	}

	private static LevelControlAllNonLevelItemLights() { }

	public LevelControlAllNonLevelItemLights() { }

	private void Awake() { }

	[CompilerGenerated]
	public static LevelControlAllNonLevelItemLights get_Instance() { }

	[CompilerGenerated]
	public static List<LevelLight> get_NonLevelItemlevelLightsInScene() { }

	private static void InitListIfNeeded() { }

	private void OnDestroy() { }

	[CompilerGenerated]
	private static void set_Instance(LevelControlAllNonLevelItemLights value) { }

	[CompilerGenerated]
	private static void set_NonLevelItemlevelLightsInScene(List<LevelLight> value) { }

	public static void SyncAllLightsOff() { }

	public static void SyncAllLightsOn() { }

	public static void SyncToggleAllLights() { }

}

