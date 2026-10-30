//Type is in global namespace

public class WebViewObject : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass29_0
	{
		public List<String> permissions; //Field offset: 0x10
		public WebViewObject <>4__this; //Field offset: 0x18
		public int grantedCount; //Field offset: 0x20
		public int deniedCount; //Field offset: 0x24

		public <>c__DisplayClass29_0() { }

		internal void <RequestFileChooserPermissions>b__0(string permission) { }

		internal void <RequestFileChooserPermissions>b__1(string permission) { }

		internal void <RequestFileChooserPermissions>b__2(string permission) { }

	}

	[CompilerGenerated]
	private sealed class <CallOnRequestFileChooserPermissionsResult>d__30 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public WebViewObject <>4__this; //Field offset: 0x20
		public bool granted; //Field offset: 0x28
		private int <i>5__2; //Field offset: 0x2C

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
		public <CallOnRequestFileChooserPermissionsResult>d__30(int <>1__state) { }

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

	private Action<String> onJS; //Field offset: 0x20
	private Action<String> onError; //Field offset: 0x28
	private Action<String> onHttpError; //Field offset: 0x30
	private Action<String> onStarted; //Field offset: 0x38
	private Action<String> onLoaded; //Field offset: 0x40
	private Action<String> onHooked; //Field offset: 0x48
	private Action<String> onCookies; //Field offset: 0x50
	private bool paused; //Field offset: 0x58
	private bool visibility; //Field offset: 0x59
	private bool alertDialogEnabled; //Field offset: 0x5A
	private bool scrollBounceEnabled; //Field offset: 0x5B
	private int mMarginLeft; //Field offset: 0x5C
	private int mMarginTop; //Field offset: 0x60
	private int mMarginRight; //Field offset: 0x64
	private int mMarginBottom; //Field offset: 0x68
	private bool mMarginRelative; //Field offset: 0x6C
	private float mMarginLeftComputed; //Field offset: 0x70
	private float mMarginTopComputed; //Field offset: 0x74
	private float mMarginRightComputed; //Field offset: 0x78
	private float mMarginBottomComputed; //Field offset: 0x7C
	private bool mMarginRelativeComputed; //Field offset: 0x80
	private AndroidJavaObject webView; //Field offset: 0x88
	private bool mVisibility; //Field offset: 0x90
	private int mKeyboardVisibleHeight; //Field offset: 0x94
	private float mResumedTimestamp; //Field offset: 0x98
	private int mLastScreenHeight; //Field offset: 0x9C

	public bool IsKeyboardVisible
	{
		 get { } //Length: 16
	}

	public WebViewObject() { }

	public void AddCustomHeader(string headerKey, string headerValue) { }

	public int AdjustBottomMargin(int bottom) { }

	private void Awake() { }

	private bool BottomAdjustmentDisabled() { }

	public void CallFromJS(string message) { }

	public void CallOnCookies(string cookies) { }

	public void CallOnError(string error) { }

	public void CallOnHooked(string message) { }

	public void CallOnHttpError(string error) { }

	public void CallOnLoaded(string url) { }

	[IteratorStateMachine(typeof(<CallOnRequestFileChooserPermissionsResult>d__30))]
	private IEnumerator CallOnRequestFileChooserPermissionsResult(bool granted) { }

	public void CallOnStarted(string url) { }

	public bool CanGoBack() { }

	public bool CanGoForward() { }

	public void ClearCache(bool includeDiskFiles) { }

	public void ClearCookies() { }

	public void ClearCustomHeader() { }

	public void EvaluateJS(string js) { }

	public bool get_IsKeyboardVisible() { }

	public bool GetAlertDialogEnabled() { }

	public void GetCookies(string url) { }

	public string GetCustomHeaderValue(string headerKey) { }

	public bool GetScrollBounceEnabled() { }

	public bool GetVisibility() { }

	public void GoBack() { }

	public void GoForward() { }

	public void Init(Action<String> cb = null, Action<String> err = null, Action<String> httpErr = null, Action<String> ld = null, Action<String> started = null, Action<String> hooked = null, Action<String> cookies = null, bool transparent = false, bool zoom = true, string ua = "", int radius = 0, int androidForceDarkMode = 0, bool enableWKWebView = true, int wkContentMode = 0, bool wkAllowsLinkPreview = true, bool wkAllowsBackForwardNavigationGestures = true, bool separated = false) { }

	public static bool IsWebViewAvailable() { }

	public void LoadHTML(string html, string baseUrl) { }

	public void LoadURL(string url) { }

	private void OnApplicationPause(bool paused) { }

	protected override void OnDestroy() { }

	public void Pause() { }

	public int Progress() { }

	public void Reload() { }

	public void RemoveCustomHeader(string headerKey) { }

	public void RequestFileChooserPermissions() { }

	public void Resume() { }

	public void SaveCookies() { }

	public void SetAlertDialogEnabled(bool e) { }

	public void SetBasicAuthInfo(string userName, string password) { }

	public void SetCameraAccess(bool allowed) { }

	public void SetCenterPositionWithScale(Vector2 center, Vector2 scale) { }

	public void SetInteractionEnabled(bool enabled) { }

	public void SetKeyboardVisible(string keyboardVisibleHeight) { }

	public void SetMargins(int left, int top, int right, int bottom, bool relative = false) { }

	public void SetMicrophoneAccess(bool allowed) { }

	public void SetScrollbarsVisibility(bool v) { }

	public void SetScrollBounceEnabled(bool e) { }

	public void SetTextZoom(int textZoom) { }

	public bool SetURLPattern(string allowPattern, string denyPattern, string hookPattern) { }

	public void SetVisibility(bool v) { }

	private void Update() { }

}

