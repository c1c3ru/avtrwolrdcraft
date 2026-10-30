namespace PazuCore;

public class UnityLifecycleListener : MonoBehaviour
{
	[CompilerGenerated]
	private static bool <IsApplicationQuitting>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private static Action OnGameResumeAction; //Field offset: 0x8
	[CompilerGenerated]
	private static Action OnGamePauseAction; //Field offset: 0x10
	[CompilerGenerated]
	private static int <ApplicationPauseCounter>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private static UnityLifecycleListener <Instance>k__BackingField; //Field offset: 0x20

	public static event Action OnGamePauseAction
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	public static event Action OnGameResumeAction
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	public private static int ApplicationPauseCounter
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 76
	}

	public private static UnityLifecycleListener Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public private static bool IsApplicationQuitting
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public UnityLifecycleListener() { }

	[CompilerGenerated]
	public static void add_OnGamePauseAction(Action value) { }

	[CompilerGenerated]
	public static void add_OnGameResumeAction(Action value) { }

	private void Awake() { }

	[CompilerGenerated]
	public static int get_ApplicationPauseCounter() { }

	[CompilerGenerated]
	public static UnityLifecycleListener get_Instance() { }

	[CompilerGenerated]
	public static bool get_IsApplicationQuitting() { }

	private void OnApplicationPause(bool pause) { }

	private void OnApplicationQuit() { }

	private void OnDestroy() { }

	private void OnGamePause() { }

	private void OnGameResume() { }

	private void OnReachabilityChanged(NetworkStatus networkStatus) { }

	[CompilerGenerated]
	public static void remove_OnGamePauseAction(Action value) { }

	[CompilerGenerated]
	public static void remove_OnGameResumeAction(Action value) { }

	[CompilerGenerated]
	private static void set_ApplicationPauseCounter(int value) { }

	[CompilerGenerated]
	private static void set_Instance(UnityLifecycleListener value) { }

	[CompilerGenerated]
	private static void set_IsApplicationQuitting(bool value) { }

}

