namespace PazuCore.ForParents;

public class ForParentsManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<String> <>9__23_4; //Field offset: 0x8
		public static Action<String> <>9__23_5; //Field offset: 0x10
		public static Action<Boolean> <>9__36_0; //Field offset: 0x18
		public static Action <>9__40_0; //Field offset: 0x20
		public static Action<Boolean> <>9__44_0; //Field offset: 0x28
		public static Action <>9__47_0; //Field offset: 0x30

		private static <>c() { }

		public <>c() { }

		internal void <CloseScene>b__44_0(bool success) { }

		internal void <OnDestroy>b__36_0(bool success) { }

		internal void <OnNewSceneLoaded>b__40_0() { }

		internal void <OpenWebView>b__23_4(string msg) { }

		internal void <OpenWebView>b__23_5(string msg) { }

		internal void <RateApp>b__47_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass43_0
	{
		public string urlPathAddition; //Field offset: 0x10

		public <>c__DisplayClass43_0() { }

		internal void <OpenScene>b__0(bool success) { }

	}

	[CompilerGenerated]
	private sealed class <Start>d__22 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ForParentsManager <>4__this; //Field offset: 0x20
		private UnityWebRequestAsyncOperation <op>5__2; //Field offset: 0x28

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
		public <Start>d__22(int <>1__state) { }

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

	private enum NewSceneLoadedOpen
	{
		None = 0,
		Purchase = 1,
		Library = 2,
		URL = 3,
	}

	private static string _previousSceneName; //Field offset: 0x0
	private static string _urlPathAddition; //Field offset: 0x8
	private static string _externalUrl; //Field offset: 0x10
	[CompilerGenerated]
	private static ForParentsManager <Instance>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private static bool <IsSceneOpen>k__BackingField; //Field offset: 0x20
	private static NewSceneLoadedOpen _newSceneLoadedOpen; //Field offset: 0x24
	[SerializeField]
	private GameObject _loading; //Field offset: 0x20
	[SerializeField]
	private CanvasScaler _canvasScaler; //Field offset: 0x28
	private WebViewObject _webViewObject; //Field offset: 0x30
	private string _currentJWT; //Field offset: 0x38
	private bool _isLoaded; //Field offset: 0x40
	private bool _loadingInProgress; //Field offset: 0x41
	private bool _isCalledError; //Field offset: 0x42
	private string lastModified; //Field offset: 0x48

	public private static ForParentsManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public private static bool IsSceneOpen
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public ForParentsManager() { }

	[CompilerGenerated]
	private void <OpenWebView>b__23_0(string msg) { }

	[CompilerGenerated]
	private void <OpenWebView>b__23_1(string msg) { }

	[CompilerGenerated]
	private void <OpenWebView>b__23_2(string msg) { }

	[CompilerGenerated]
	private void <OpenWebView>b__23_3(string msg) { }

	[CompilerGenerated]
	private void <OpenWebView>b__23_6() { }

	[CompilerGenerated]
	private void <OpenWebView>b__23_7() { }

	[CompilerGenerated]
	private void <ShowUnsupportedDeviceMessage>b__32_0() { }

	[CompilerGenerated]
	private void <Start>b__22_0() { }

	private void Awake() { }

	public void CloseScene() { }

	private string CreateJWTData(bool isWebView) { }

	private string CreateUrlToLoad(string path = "") { }

	[CompilerGenerated]
	public static ForParentsManager get_Instance() { }

	[CompilerGenerated]
	public static bool get_IsSceneOpen() { }

	private string GetBaseUrl() { }

	private Dictionary<String, Object> GetDataFromMessage(String[] array) { }

	private string GetWebViewTextError(string msg) { }

	public void HideLoading() { }

	private bool OnBackButton() { }

	private void OnDestroy() { }

	private void OnGameResume() { }

	private void OnIAPEnded(IAPResult result) { }

	private static void OnNewSceneLoaded(Scene scene, LoadSceneMode mode) { }

	private void OnUserSync(SyncType syncType) { }

	private void OpenExternalURL() { }

	private void OpenLibrary() { }

	public void OpenPurchase() { }

	public static void OpenScene(string urlPathAddition = null) { }

	private void OpenWebView() { }

	private void RateApp() { }

	private void RestorePurchases() { }

	public void ReturnToWebView(string path = null) { }

	[CompilerGenerated]
	private static void set_Instance(ForParentsManager value) { }

	[CompilerGenerated]
	private static void set_IsSceneOpen(bool value) { }

	private void SetAccessTokenFromMessage(String[] array) { }

	private void SetWebViewLoaded(bool isLoaded) { }

	public void ShowLoading() { }

	private void ShowUnsupportedDeviceMessage() { }

	[IteratorStateMachine(typeof(<Start>d__22))]
	private IEnumerator Start() { }

}

