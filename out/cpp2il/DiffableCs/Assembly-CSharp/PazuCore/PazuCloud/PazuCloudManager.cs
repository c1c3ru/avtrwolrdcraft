namespace PazuCore.PazuCloud;

public class PazuCloudManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Boolean> <>9__42_0; //Field offset: 0x8
		public static Func<Boolean> <>9__42_1; //Field offset: 0x10
		public static Func<Boolean> <>9__55_0; //Field offset: 0x18
		public static Func<Boolean> <>9__71_0; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal bool <PrepareIntegrityToken>b__42_0() { }

		internal bool <PrepareIntegrityToken>b__42_1() { }

		internal bool <SendOperationWhenPossible>b__71_0() { }

		internal bool <TryPerformUserActionImplement>b__55_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass53_0
	{
		public PazuCloudManager <>4__this; //Field offset: 0x10
		public Action action; //Field offset: 0x18

		public <>c__DisplayClass53_0() { }

		internal bool <TryPerformUserAction>b__0() { }

		internal void <TryPerformUserAction>b__1() { }

		internal void <TryPerformUserAction>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass55_0
	{
		public Action action; //Field offset: 0x10
		public PazuCloudManager <>4__this; //Field offset: 0x18

		public <>c__DisplayClass55_0() { }

		internal void <TryPerformUserActionImplement>b__1() { }

		internal void <TryPerformUserActionImplement>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass56_0
	{
		public string op; //Field offset: 0x10
		public Action<Response> onResponse; //Field offset: 0x18

		public <>c__DisplayClass56_0() { }

		internal void <SetGameData>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass57_0
	{
		public string op; //Field offset: 0x10
		public Action<Response> onResponse; //Field offset: 0x18

		public <>c__DisplayClass57_0() { }

		internal void <ConsumeProducts>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass58_0
	{
		public string op; //Field offset: 0x10
		public Action<GetGameDataResponse> onResponse; //Field offset: 0x18

		public <>c__DisplayClass58_0() { }

		internal void <GetGameData>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass59_0
	{
		public string op; //Field offset: 0x10
		public Action<GetNotConsumedProductsResponse> onResponse; //Field offset: 0x18

		public <>c__DisplayClass59_0() { }

		internal void <GetNotConsumedProducts>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass60_0
	{
		public string op; //Field offset: 0x10
		public Action<Response> onResponse; //Field offset: 0x18

		public <>c__DisplayClass60_0() { }

		internal void <SubscribeToNewsletter>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass61_0
	{
		public string op; //Field offset: 0x10
		public Action<RegisterDeviceResponse> onResponse; //Field offset: 0x18

		public <>c__DisplayClass61_0() { }

		internal void <CreateNewDeviceAndUseIt>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass62_0
	{
		public string op; //Field offset: 0x10
		public Action<Response> onResponse; //Field offset: 0x18

		public <>c__DisplayClass62_0() { }

		internal void <ChangePassword>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass63_0
	{
		public string op; //Field offset: 0x10
		public Action<Response> onResponse; //Field offset: 0x18

		public <>c__DisplayClass63_0() { }

		internal void <Logout>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass64_0
	{
		public string op; //Field offset: 0x10
		public Action<Response> onResponse; //Field offset: 0x18

		public <>c__DisplayClass64_0() { }

		internal void <LegacyClientAccessToken>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass65_0
	{
		public string op; //Field offset: 0x10
		public Action<ClientStateResponse> onResponse; //Field offset: 0x18

		public <>c__DisplayClass65_0() { }

		internal void <GetClientState>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass66_0
	{
		public string op; //Field offset: 0x10
		public Action<Response> onResponse; //Field offset: 0x18

		public <>c__DisplayClass66_0() { }

		internal void <SendManageDevicesEmail>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass68_0
	{
		public PazuCloudManager <>4__this; //Field offset: 0x10
		public VerifyReceiptActionType actionType; //Field offset: 0x18
		public string op; //Field offset: 0x20
		public Action<Response> onResponse; //Field offset: 0x28

		public <>c__DisplayClass68_0() { }

		internal void <VerifyReceipt>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass71_0
	{
		public PazuCloudManager <>4__this; //Field offset: 0x10
		public string op; //Field offset: 0x18
		public Dictionary<String, Object> data; //Field offset: 0x20
		public Action<String> onResponse; //Field offset: 0x28
		public bool shouldLog; //Field offset: 0x30

		public <>c__DisplayClass71_0() { }

		internal void <SendOperationWhenPossible>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <PrepareIntegrityToken>d__42 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Action onFinish; //Field offset: 0x20
		public PazuCloudManager <>4__this; //Field offset: 0x28
		private PlayAsyncOperation<StandardIntegrityTokenProvider, StandardIntegrityErrorCode> <integrityTokenProviderOperation>5__2; //Field offset: 0x30
		private StandardIntegrityTokenProvider <integrityTokenProvider>5__3; //Field offset: 0x38
		private PlayAsyncOperation<StandardIntegrityToken, StandardIntegrityErrorCode> <integrityTokenOperation>5__4; //Field offset: 0x40

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
		public <PrepareIntegrityToken>d__42(int <>1__state) { }

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
	private sealed class <SendRequest>d__75 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string jwtData; //Field offset: 0x20
		public string url; //Field offset: 0x28
		public PazuCloudManager <>4__this; //Field offset: 0x30
		public Action<String> onResponse; //Field offset: 0x38
		private UnityWebRequest <webRequest>5__2; //Field offset: 0x40

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
		public <SendRequest>d__75(int <>1__state) { }

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

	internal sealed class OverrideVerifyReceiptOpDelegate : MulticastDelegate
	{

		public OverrideVerifyReceiptOpDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(VerifyReceiptActionType actionType, out string op, out Dictionary<String, Object>& extraData, AsyncCallback callback, object object) { }

		public override bool EndInvoke(out string op, out Dictionary<String, Object>& extraData, IAsyncResult result) { }

		public override bool Invoke(VerifyReceiptActionType actionType, out string op, out Dictionary<String, Object>& extraData) { }

	}

	internal sealed class OverrideVerifyReceiptResponseHandingDelegate : MulticastDelegate
	{

		public OverrideVerifyReceiptResponseHandingDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(VerifyReceiptActionType actionType, string responseText, out Response response, AsyncCallback callback, object object) { }

		public override bool EndInvoke(out Response response, IAsyncResult result) { }

		public override bool Invoke(VerifyReceiptActionType actionType, string responseText, out Response response) { }

	}

	private enum UnityServicesState
	{
		PreInitializing = 0,
		Initializing = 1,
		InitializeSuccess = 2,
		InitializeFailed = 3,
	}

	public const int CMS_VERSION = 6; //Field offset: 0x0
	public const string PUBLIC_JWT_PASSPHRASE = "e2bf6030cefc6e89f6bf187c09463568786db2a5c5adc916088549dc82f96a7f742aeaba7dce74b8dc980613ccb438b530373459f16db0ae90e300a65aff75cd"; //Field offset: 0x0
	[CompilerGenerated]
	private static PazuCloudManager <Instance>k__BackingField; //Field offset: 0x0
	private UnityServicesState _currentUnityServicesState; //Field offset: 0x20
	private EnvType _env; //Field offset: 0x24
	[CompilerGenerated]
	private string <IntegrityToken>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private PazuCloudGameDataManager <GameDataManager>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private PazuCloudOfflineManager <OfflineManager>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private PazuCloudChangeTrackingManager <ChangeTrackingManager>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	private OverrideVerifyReceiptOpDelegate OverrideVerifyReceiptOpAction; //Field offset: 0x48
	[CompilerGenerated]
	private OverrideVerifyReceiptResponseHandingDelegate OverrideVerifyReceiptResponseHandlingAction; //Field offset: 0x50

	public event OverrideVerifyReceiptOpDelegate OverrideVerifyReceiptOpAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event OverrideVerifyReceiptResponseHandingDelegate OverrideVerifyReceiptResponseHandlingAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public private PazuCloudChangeTrackingManager ChangeTrackingManager
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public EnvType Env
	{
		 get { } //Length: 8
	}

	public private PazuCloudGameDataManager GameDataManager
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private static PazuCloudManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public private string IntegrityToken
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private PazuCloudOfflineManager OfflineManager
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public static int PAZUCORE_VERSION
	{
		 get { } //Length: 8
	}

	private string UnityServicesEnvironment
	{
		private get { } //Length: 136
	}

	public PazuCloudManager() { }

	[CompilerGenerated]
	public void add_OverrideVerifyReceiptOpAction(OverrideVerifyReceiptOpDelegate value) { }

	[CompilerGenerated]
	public void add_OverrideVerifyReceiptResponseHandlingAction(OverrideVerifyReceiptResponseHandingDelegate value) { }

	private void AddHeadersToRequest(UnityWebRequest unityWebRequest) { }

	private void Awake() { }

	private static string CalculateSHA256(string input) { }

	public bool CanUserPerformOperations() { }

	public void ChangePassword(string password, string newPassword, string confirmPassword, Action<Response> onResponse) { }

	public void ConsumeProducts(List<Int32> consumableIds, string gameDataJson, Action<Response> onResponse) { }

	public void CreateNewDeviceAndUseIt(Action<RegisterDeviceResponse> onResponse) { }

	private void FillDataWithPlatformData(Dictionary<String, Object> data) { }

	[CompilerGenerated]
	public PazuCloudChangeTrackingManager get_ChangeTrackingManager() { }

	public EnvType get_Env() { }

	[CompilerGenerated]
	public PazuCloudGameDataManager get_GameDataManager() { }

	[CompilerGenerated]
	public static PazuCloudManager get_Instance() { }

	[CompilerGenerated]
	public string get_IntegrityToken() { }

	[CompilerGenerated]
	public PazuCloudOfflineManager get_OfflineManager() { }

	public static int get_PAZUCORE_VERSION() { }

	private string get_UnityServicesEnvironment() { }

	public void GetClientState(Action<ClientStateResponse> onResponse) { }

	public void GetGameData(Action<GetGameDataResponse> onResponse) { }

	public void GetGooglePlayIntegrityToken(Action onFinish) { }

	private string GetHost() { }

	private string GetJwtData(Dictionary<String, Object> data, string deviceToken, string jwtPassphrase, string accessToken, string opForEditorLog) { }

	public void GetNotConsumedProducts(Action<GetNotConsumedProductsResponse> onResponse) { }

	public string GetXApiKey() { }

	public void InitializeUnityServicesIfNeeded() { }

	public void LegacyClientAccessToken(Action<Response> onResponse) { }

	public void Logout(Action<Response> onResponse) { }

	private void OnDestroy() { }

	public void OnGamePause() { }

	public void OnGameResume() { }

	private void OnInitialized() { }

	private void OnInitializeFailed(Exception exception) { }

	public void OpenForgotPasswordUrl() { }

	public void PrepareDataForRequest(string op, Dictionary<String, Object> data, out string url, out string jwtData) { }

	[IteratorStateMachine(typeof(<PrepareIntegrityToken>d__42))]
	private IEnumerator PrepareIntegrityToken(Action onFinish = null) { }

	[CompilerGenerated]
	public void remove_OverrideVerifyReceiptOpAction(OverrideVerifyReceiptOpDelegate value) { }

	[CompilerGenerated]
	public void remove_OverrideVerifyReceiptResponseHandlingAction(OverrideVerifyReceiptResponseHandingDelegate value) { }

	public void SendManageDevicesEmail(Action<Response> onResponse) { }

	public void SendOperation(string op, Dictionary<String, Object> data, Action<String> onResponse, bool shouldLog = true) { }

	public Coroutine SendOperationWhenPossible(string op, Dictionary<String, Object> data, Action<String> onResponse, bool shouldLog = true) { }

	[IteratorStateMachine(typeof(<SendRequest>d__75))]
	private IEnumerator SendRequest(string url, string jwtData, Action<String> onResponse) { }

	[CompilerGenerated]
	private void set_ChangeTrackingManager(PazuCloudChangeTrackingManager value) { }

	[CompilerGenerated]
	private void set_GameDataManager(PazuCloudGameDataManager value) { }

	[CompilerGenerated]
	private static void set_Instance(PazuCloudManager value) { }

	[CompilerGenerated]
	private void set_IntegrityToken(string value) { }

	[CompilerGenerated]
	private void set_OfflineManager(PazuCloudOfflineManager value) { }

	public void SetGameData(string gameDataJson, Action<Response> onResponse) { }

	private void ShowServerIsBusyMessage() { }

	private void Start() { }

	public void SubscribeToNewsletter(string email, Action<Response> onResponse) { }

	public void TryPerformUserAction(Action action) { }

	private void TryPerformUserActionImplement(Action action) { }

	public void VerifyReceipt(VerifyReceiptActionType actionType, string receiptData, string entitlements, Action<Response> onResponse) { }

}

