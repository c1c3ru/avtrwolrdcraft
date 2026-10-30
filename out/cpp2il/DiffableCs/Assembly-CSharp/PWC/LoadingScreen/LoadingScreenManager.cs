namespace PWC.LoadingScreen;

public class LoadingScreenManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public LoadingScreenScreen screen; //Field offset: 0x10

		public <>c__DisplayClass8_0() { }

		internal void <OnSceneLoaded>b__0() { }

	}

	[CompilerGenerated]
	private static LoadingScreenManager <Instance>k__BackingField; //Field offset: 0x0
	[SerializeField]
	private LoadingScreenScreen _screenPrefab; //Field offset: 0x20
	protected LoadingScreenScreen _currentScreen; //Field offset: 0x28

	public private static LoadingScreenManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public LoadingScreenManager() { }

	private void Awake() { }

	[CompilerGenerated]
	public static LoadingScreenManager get_Instance() { }

	private void OnDestroy() { }

	protected override void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) { }

	[CompilerGenerated]
	private static void set_Instance(LoadingScreenManager value) { }

	public void StartSceneTransition(Action onFadeComplete) { }

}

