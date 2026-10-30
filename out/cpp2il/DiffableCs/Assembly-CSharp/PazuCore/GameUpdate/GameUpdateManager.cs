namespace PazuCore.GameUpdate;

public class GameUpdateManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<GameUpdateResponse> <>9__6_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <OnSceneLoaded>b__6_0(GameUpdateResponse response) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public string op; //Field offset: 0x10
		public Action<GameUpdateResponse> onFinish; //Field offset: 0x18

		public <>c__DisplayClass7_0() { }

		internal void <GetGameUpdateFromServer>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private static GameUpdateManager <Instance>k__BackingField; //Field offset: 0x0

	public private static GameUpdateManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public GameUpdateManager() { }

	private void Awake() { }

	[CompilerGenerated]
	public static GameUpdateManager get_Instance() { }

	private void GetGameUpdateFromServer(Action<GameUpdateResponse> onFinish) { }

	private void OnDestroy() { }

	private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) { }

	[CompilerGenerated]
	private static void set_Instance(GameUpdateManager value) { }

}

