namespace PazuCore;

public class Loader : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<PlayInstallReferrerDetails> <>9__28_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <Awake>b__28_0(PlayInstallReferrerDetails referrerDetails) { }

	}

	[CompilerGenerated]
	private static Func<Boolean> OverrideLoadCompanySplash; //Field offset: 0x0
	public GameObject backgroundMusic; //Field offset: 0x20
	public GameObject localizationManager; //Field offset: 0x28
	public GameObject screenLoader; //Field offset: 0x30
	public GameObject settingsManager; //Field offset: 0x38
	public GameObject soundManager; //Field offset: 0x40
	public GameObject windowManager; //Field offset: 0x48
	public GameObject purchaser; //Field offset: 0x50
	public GameObject blackFridayManager; //Field offset: 0x58
	public GameObject fileManager; //Field offset: 0x60
	public GameObject nativeEventsReceiver; //Field offset: 0x68
	public GameObject pazuCloudManager; //Field offset: 0x70
	public GameObject analyticsManager; //Field offset: 0x78
	public GameObject remoteAssetsManager; //Field offset: 0x80
	public GameObject unityLifecycleListener; //Field offset: 0x88
	public GameObject androidKeycainManager; //Field offset: 0x90
	public GameObject androidFileManager; //Field offset: 0x98
	public GameObject androidPazuGamesOnDeviceGetter; //Field offset: 0xA0
	public GameObject endSessionDataManager; //Field offset: 0xA8
	public GameObject deepLinkManager; //Field offset: 0xB0
	public GameObject gameUpdateManager; //Field offset: 0xB8
	public GameObject screenOrientationManager; //Field offset: 0xC0
	public GameObject pazuGameModeManager; //Field offset: 0xC8
	public GameObject addressablesManager; //Field offset: 0xD0
	public GameObject timeLimitDataManager; //Field offset: 0xD8
	public AddressablesFeaturesMap addressablesFeaturesMap; //Field offset: 0xE0

	public static event Func<Boolean> OverrideLoadCompanySplash
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public Loader() { }

	[CompilerGenerated]
	public static void add_OverrideLoadCompanySplash(Func<Boolean> value) { }

	private void Awake() { }

	[CompilerGenerated]
	public static void remove_OverrideLoadCompanySplash(Func<Boolean> value) { }

	private void Start() { }

}

