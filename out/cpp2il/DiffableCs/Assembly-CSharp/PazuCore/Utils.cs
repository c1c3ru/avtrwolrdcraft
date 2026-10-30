namespace PazuCore;

[Extension]
public static class Utils
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__55_0; //Field offset: 0x8
		public static Action <>9__56_1; //Field offset: 0x10
		public static Func<CultureInfo, Boolean> <>9__77_0; //Field offset: 0x18
		public static Func<CultureInfo, RegionInfo> <>9__77_1; //Field offset: 0x20
		public static Func<RegionInfo, String> <>9__77_3; //Field offset: 0x28
		public static Func<Char, Boolean> <>9__77_4; //Field offset: 0x30
		public static Func<Char, Int32, String> <>9__82_0; //Field offset: 0x38

		private static <>c() { }

		public <>c() { }

		internal void <BuyNonConsumable>b__56_1() { }

		internal string <ConvertCamelCaseToUnderscoreCase>b__82_0(char x, int i) { }

		internal void <ShowToManyDevicesMessage>b__55_0() { }

		internal bool <TryGetCultureInfoAndSymbol>b__77_0(CultureInfo c) { }

		internal RegionInfo <TryGetCultureInfoAndSymbol>b__77_1(CultureInfo culture) { }

		internal string <TryGetCultureInfoAndSymbol>b__77_3(RegionInfo ri) { }

		internal bool <TryGetCultureInfoAndSymbol>b__77_4(char c) { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass110_0
	{
		public Action beforeLoadSceneAction; //Field offset: 0x0
		public Action overrideLoadSceneAction; //Field offset: 0x8
		public string sceneName; //Field offset: 0x10

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass41_0
	{
		public Action<Boolean> onFinish; //Field offset: 0x10

		public <>c__DisplayClass41_0() { }

		internal void <RateApp>b__0() { }

		internal void <RateApp>b__1() { }

		internal void <RateApp>b__3() { }

		internal void <RateApp>b__4() { }

		internal void <RateApp>g__ShowRateUsWindow|2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass51_0
	{
		public Byte[] data; //Field offset: 0x10

		public <>c__DisplayClass51_0() { }

		internal void <DownloadTextureAndSave>b__0(Byte[] newData) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass57_0
	{
		public string productName; //Field offset: 0x10
		public string entitlements; //Field offset: 0x18

		public <>c__DisplayClass57_0() { }

		internal void <BuyProduct>b__1() { }

		internal void <BuyProduct>g__Buy|0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass59_0
	{
		public string name; //Field offset: 0x10
		public Action<String> assign; //Field offset: 0x18

		public <>c__DisplayClass59_0() { }

		internal void <DownloadAudioClipAndSave>b__0(AudioClip audioClip, Byte[] bytes) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass77_0
	{
		public string ISOCurrencySymbol; //Field offset: 0x10

		public <>c__DisplayClass77_0() { }

		internal bool <TryGetCultureInfoAndSymbol>b__2(RegionInfo ri) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass77_1
	{
		public string localSymbol; //Field offset: 0x10

		public <>c__DisplayClass77_1() { }

		internal bool <TryGetCultureInfoAndSymbol>b__5(CultureInfo culture) { }

	}

	[CompilerGenerated]
	private sealed class <DownloadAudioClip>d__60 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string uri; //Field offset: 0x20
		public Action onFailure; //Field offset: 0x28
		public Action<AudioClip, Byte[]> assignClip; //Field offset: 0x30
		private UnityWebRequest <webRequest>5__2; //Field offset: 0x38
		private UnityWebRequest <>7__wrap2; //Field offset: 0x40

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
		public <DownloadAudioClip>d__60(int <>1__state) { }

		private void <>m__Finally1() { }

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

	[CompilerGenerated]
	private sealed class <DownloadAudioClipAndSave>d__59 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string name; //Field offset: 0x20
		public Action<String> assign; //Field offset: 0x28
		public string url; //Field offset: 0x30
		public Action onFailure; //Field offset: 0x38

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
		public <DownloadAudioClipAndSave>d__59(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <DownloadTexture>d__58 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Action<Texture2D> assign; //Field offset: 0x20
		public Action<Byte[]> assignData; //Field offset: 0x28
		public string uri; //Field offset: 0x30
		private UnityWebRequest <webRequest>5__2; //Field offset: 0x38
		private UnityWebRequest <>7__wrap2; //Field offset: 0x40

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
		public <DownloadTexture>d__58(int <>1__state) { }

		private void <>m__Finally1() { }

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

	[CompilerGenerated]
	private sealed class <DownloadTextureAndSave>d__51 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string url; //Field offset: 0x20
		private <>c__DisplayClass51_0 <>8__1; //Field offset: 0x28
		public bool isSharedTexture; //Field offset: 0x30
		public string name; //Field offset: 0x38
		public Action<String> assign; //Field offset: 0x40
		public Action onFailed; //Field offset: 0x48

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
		public <DownloadTextureAndSave>d__51(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <ExecuteAfterEndOfFrameCoroutine>d__40 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Action action; //Field offset: 0x20

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
		public <ExecuteAfterEndOfFrameCoroutine>d__40(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <ExecuteNextFrameCoroutine>d__38 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Action action; //Field offset: 0x20

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
		public <ExecuteNextFrameCoroutine>d__38(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <ExecuteOnConditionCoroutine>d__30 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float checkInterval; //Field offset: 0x20
		public float maxWaitTime; //Field offset: 0x24
		public Action onMaxWaitTimeReached; //Field offset: 0x28
		public Func<Boolean> condition; //Field offset: 0x30
		public Action action; //Field offset: 0x38
		private WaitForSeconds <wait>5__2; //Field offset: 0x40
		private float <safeTimer>5__3; //Field offset: 0x48

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
		public <ExecuteOnConditionCoroutine>d__30(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <RateAppDirect>d__42 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		private string <url>5__2; //Field offset: 0x20
		private string <urlfallback>5__3; //Field offset: 0x28
		private string <package>5__4; //Field offset: 0x30
		private PlayAsyncOperation<PlayReviewInfo, ReviewErrorCode> <requestFlowOperation>5__5; //Field offset: 0x38
		private PlayAsyncOperation<VoidResult, ReviewErrorCode> <launchFlowOperation>5__6; //Field offset: 0x40

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
		public <RateAppDirect>d__42(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <SetRealTimeTimerCoroutine>d__36 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float duration; //Field offset: 0x20
		public Action action; //Field offset: 0x28

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
		public <SetRealTimeTimerCoroutine>d__36(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <SetSecondsTickTimer>d__32 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Action onTickAction; //Field offset: 0x20
		public int duration; //Field offset: 0x28
		private int <secondsPassed>5__2; //Field offset: 0x2C

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
		public <SetSecondsTickTimer>d__32(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <SetTimerCoroutine>d__34 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float duration; //Field offset: 0x20
		public Action action; //Field offset: 0x28

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
		public <SetTimerCoroutine>d__34(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <TryLoadGameplaySceneInternal>d__110 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Action beforeLoadSceneAction; //Field offset: 0x20
		public Action overrideLoadSceneAction; //Field offset: 0x28
		public string sceneName; //Field offset: 0x30
		private <>c__DisplayClass110_0 <>8__1; //Field offset: 0x38
		public Action onLoadTimeLimitAction; //Field offset: 0x50

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
		public <TryLoadGameplaySceneInternal>d__110(int <>1__state) { }

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

	internal enum EditorForcePlatformType
	{
		None = 0,
		Android = 1,
		IOS = 2,
	}

	private static ReviewManager _reviewManager; //Field offset: 0x0
	private const string EDITOR_FORCE_PLATFORM_KEY = "PazuCore_EditorForcePlatform"; //Field offset: 0x0
	private static PlayReviewInfo _playReviewInfo; //Field offset: 0x8
	private static EditorForcePlatformType _editorForcePlatform; //Field offset: 0x10
	private static int _mainThreadId; //Field offset: 0x14
	[CompilerGenerated]
	private static Nullable<Boolean> <IsValidVersionResult>k__BackingField; //Field offset: 0x18

	public static bool IsAndroid
	{
		 get { } //Length: 48
	}

	public static bool IsEditor
	{
		 get { } //Length: 8
	}

	public static bool IsIOS
	{
		 get { } //Length: 48
	}

	internal static Nullable<Boolean> IsValidVersionResult
	{
		[CompilerGenerated]
		private get { } //Length: 72
		[CompilerGenerated]
		internal set { } //Length: 76
	}

	[CompilerGenerated]
	internal static void <BuyNonConsumable>g__Buy|56_0() { }

	[CompilerGenerated]
	internal static Vector2 <GetScrollRectCenteredNormalizedPosition>g__GetSize|95_0(Vector3[] corners) { }

	[CompilerGenerated]
	internal static void <TryLoadGameplaySceneInternal>g__LoadGameplayScene|110_0(ref <>c__DisplayClass110_0 unnamed_param_0) { }

	public static bool AssertIsValidUrl(string url, bool logErrorIfNotValid = true) { }

	public static void BuyNonConsumable(bool withParentalGate = true) { }

	public static void BuyProduct(string productName, string entitlements = null, bool withParentalGate = true) { }

	public static string CalculateMD5Hash(Byte[] inputBytes) { }

	public static string CalculateMD5Hash(string input) { }

	public static string CalculateSHA1(string input) { }

	public static string CalculateSHA256(Byte[] bytes) { }

	public static bool CanShowUrlLog() { }

	public static T CastValueFromJson(object value) { }

	public static string ConvertBase64StringToString(string base64String) { }

	public static string ConvertCamelCaseToUnderscoreCase(string str) { }

	public static string ConvertStringToBase64String(string stringToConvert) { }

	public static Sprite CreateSprite(Texture2D texture, SpriteMeshType spriteMeshType = 0) { }

	[IteratorStateMachine(typeof(<DownloadAudioClip>d__60))]
	public static IEnumerator DownloadAudioClip(string uri, Action<AudioClip, Byte[]> assignClip, Action onFailure = null) { }

	[IteratorStateMachine(typeof(<DownloadAudioClipAndSave>d__59))]
	public static IEnumerator DownloadAudioClipAndSave(string name, string url, Action<String> assign, Action onFailure = null) { }

	[IteratorStateMachine(typeof(<DownloadTexture>d__58))]
	public static IEnumerator DownloadTexture(string uri, Action<Texture2D> assign = null, Action<Byte[]> assignData = null) { }

	[IteratorStateMachine(typeof(<DownloadTextureAndSave>d__51))]
	public static IEnumerator DownloadTextureAndSave(string name, string url, Action<String> assign, Action onFailed = null, bool isSharedTexture = false) { }

	[Extension]
	public static Coroutine ExecuteAfterEndOfFrame(MonoBehaviour monoBehaviour, Action action) { }

	[IteratorStateMachine(typeof(<ExecuteAfterEndOfFrameCoroutine>d__40))]
	private static IEnumerator ExecuteAfterEndOfFrameCoroutine(Action action) { }

	[Extension]
	public static Coroutine ExecuteNextFrame(MonoBehaviour monoBehaviour, Action action) { }

	[IteratorStateMachine(typeof(<ExecuteNextFrameCoroutine>d__38))]
	private static IEnumerator ExecuteNextFrameCoroutine(Action action) { }

	[Extension]
	public static Coroutine ExecuteOnCondition(MonoBehaviour monoBehaviour, Func<Boolean> condition, Action action, float checkInterval = 0,1, float maxWaitTime = -1, Action onMaxWaitTimeReached = null) { }

	[IteratorStateMachine(typeof(<ExecuteOnConditionCoroutine>d__30))]
	private static IEnumerator ExecuteOnConditionCoroutine(Func<Boolean> condition, Action action, float checkInterval, float maxWaitTime, Action onMaxWaitTimeReached) { }

	public static float FitRectTransfromWidthToText(RectTransform rectTransform, Text text, float minDelta = 100, float maxWidth = 1024, bool shrinkTextIfNeeded = false) { }

	public static float FitUIContentToScreen(Transform transformToScale, RectTransform screen, Rect rectToConsider = null, bool considerWidth = true, bool considerHeight = true) { }

	public static string FormatPrice(string ISOCurrency, float price) { }

	public static string GenerateRandomString(int length, Random random = null) { }

	public static bool get_IsAndroid() { }

	public static bool get_IsEditor() { }

	public static bool get_IsIOS() { }

	[CompilerGenerated]
	private static Nullable<Boolean> get_IsValidVersionResult() { }

	public static SceneName GetAnalytcisSceneName(string sceneName) { }

	public static int GetAndroidSDKVersion() { }

	public static void GetAndroidStoreUrl(LibraryGame game, out string url, out string urlFallback, out string package) { }

	public static T GetComponentInParentIncludeInactive(GameObject gameObject) { }

	public static List<T> GetComponentsInImmediateChildren(Transform transform) { }

	public static string GetDeviceName() { }

	public static Dictionary<String, T> GetDictionaryFromJsonDictionary(Dictionary<String, Object> dict) { }

	public static T GetEnumFromString(string fromString, T defaultValue = null) { }

	public static string GetGamesAmountToView(bool addPlusIfNeeded) { }

	public static Version GetIOSVersion() { }

	public static string GetKeyForEnvironment(string key) { }

	public static List<T> GetListFromJsonList(List<Object> list) { }

	public static List<T> GetListFromString(string stringToParse) { }

	public static string GetLocalTimeZoneDSTOffset() { }

	public static long GetLongPlayerPrefs(string key, long defaultValue) { }

	public static PlatformType GetPlatformTypeForCloud() { }

	public static float GetScreenAspectRatio() { }

	public static ScreenType GetScreenType() { }

	public static Vector2 GetScrollRectCenteredNormalizedPosition(ScrollRect scrollRect, Transform centerOn) { }

	public static long GetTimeNow() { }

	public static UScreenType GetUScreenType() { }

	public static T GetValueFromJsonDictionary(Dictionary<String, Object> dictionary, String[] keysPath) { }

	public static void HideAvalibleLoading() { }

	public static void IncrementPlayerPrefsInt(string key) { }

	public static bool IsAndroidBuild() { }

	public static bool IsDeviceWithLowMemory() { }

	public static bool IsFirstAppLaunch() { }

	public static bool IsGamePurchased() { }

	public static bool IsGameUnlocked() { }

	public static bool IsLandscape() { }

	public static bool IsMainThread() { }

	public static bool IsPortrait() { }

	public static bool IsStandaloneBuild() { }

	public static bool IsTallScreen() { }

	public static bool IsUnitTestingRunning() { }

	public static bool IsValidVersion() { }

	public static bool IsVeryTallScreen() { }

	public static bool IsVeryWideScreen() { }

	public static bool IsWideScreen() { }

	private static void LoadEditorForcePlatformIfNeeded() { }

	public static void LoadFirstGameScene(SceneName sceneName, string fallbackGameSceneName) { }

	public static T LoadFromResources(string path) { }

	public static void OnGamePlaySessionEnded() { }

	public static void OnInteractionWithLockedItem() { }

	public static void OpenSpecialUrlAndroid(string url, string package, string fallbackUrl = "", Action fallbackAction = null) { }

	public static void RateApp(bool withParentalGate = true, Action<Boolean> onFinish = null) { }

	[IteratorStateMachine(typeof(<RateAppDirect>d__42))]
	public static IEnumerator RateAppDirect() { }

	[CompilerGenerated]
	internal static void set_IsValidVersionResult(Nullable<Boolean> value) { }

	public static void SetForcePlatformForNextPlayMode(EditorForcePlatformType type) { }

	public static void SetGameSoundMute(bool mute, Int32[] excludeChannels) { }

	public static void SetLongPlayerPrefs(string key, long value) { }

	public static void SetMainThreadID() { }

	[Extension]
	public static Coroutine SetRealTimeTimer(MonoBehaviour monoBehaviour, float duration, Action action) { }

	[IteratorStateMachine(typeof(<SetRealTimeTimerCoroutine>d__36))]
	private static IEnumerator SetRealTimeTimerCoroutine(float duration, Action action) { }

	[Extension]
	public static Coroutine SetSecondsTickTimer(MonoBehaviour monoBehaviour, int duration, Action onTickAction) { }

	[IteratorStateMachine(typeof(<SetSecondsTickTimer>d__32))]
	private static IEnumerator SetSecondsTickTimer(int duration, Action onTickAction) { }

	[Extension]
	public static Coroutine SetTimer(MonoBehaviour monoBehaviour, float duration, Action action) { }

	[IteratorStateMachine(typeof(<SetTimerCoroutine>d__34))]
	private static IEnumerator SetTimerCoroutine(float duration, Action action) { }

	public static bool ShouldRateUsButtonBeVisible() { }

	public static bool ShouldUsePurchaseService(out bool showTooManyDevices) { }

	public static void ShowAvalibleLoading() { }

	public static void ShowToManyDevicesMessage() { }

	public static void ShuffleIList(IList<T> list, Random random = null) { }

	public static void SystemLog(object message) { }

	public static void SystemLogError(object message, object context = null) { }

	public static void SystemLogException(string message, Exception innerException, object context = null) { }

	public static bool TryGetCultureInfoAndSymbol(string ISOCurrencySymbol, out CultureInfo cultureInfo, out string symbol) { }

	public static bool TryGetEnumFromString(string fromString, out T outValue) { }

	public static bool TryGetResourcesPathFromAssetPath(string assetPath, out string resourcesPath) { }

	public static bool TryGetValueFromJsonDictionary(Dictionary<String, Object> dictionary, bool logErrorIfFailure, out T result, String[] keysPath) { }

	public static void TryLoadGameplayScene(string sceneName = null, Action beforeLoadSceneAction = null, Action overrideLoadSceneAction = null, Action onLoadTimeLimitAction = null) { }

	[IteratorStateMachine(typeof(<TryLoadGameplaySceneInternal>d__110))]
	private static IEnumerator TryLoadGameplaySceneInternal(string sceneName, Action beforeLoadSceneAction, Action overrideLoadSceneAction, Action onLoadTimeLimitAction) { }

	public static bool TryLoadSerializableClassFromPlayerPrefs(string playerPrefsKey, out T loadedObject) { }

	public static bool TryLoadSerializableClassFromResources(string path, out T loadedObject) { }

	public static bool TryLoadSerializableClassFromSharedTextFile(string fileName, out T loadedObject) { }

	public static bool TryLoadSerializableClassFromString(string dataString, out T loadedObject) { }

	public static bool TryLoadSerializableClassFromTextFile(string fileName, out T loadedObject) { }

}

