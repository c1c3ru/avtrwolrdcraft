namespace PazuCore.PazuCoreAddressables;

public class AddressablesManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<AddressablesFeatureBase, Int32> <>9__38_0; //Field offset: 0x8
		public static Action<AddressablesFeatureBase> <>9__52_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal int <DownloadDependenciesIfNeeded>b__38_0(AddressablesFeatureBase feature) { }

		internal void <OnGameResume>b__52_0(AddressablesFeatureBase feature) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass35_0
	{
		public string op; //Field offset: 0x10
		public AddressablesManager <>4__this; //Field offset: 0x18
		public string languageCode; //Field offset: 0x20
		public string countryCode; //Field offset: 0x28
		public Action <>9__1; //Field offset: 0x30

		public <>c__DisplayClass35_0() { }

		internal void <GetAddressablesData>b__0(string responseText) { }

		internal void <GetAddressablesData>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <DownloadDependenciesIfNeeded>d__38 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AddressablesManager <>4__this; //Field offset: 0x20
		private Enumerator<AddressablesFeatureBase> <>7__wrap1; //Field offset: 0x28
		private AddressablesFeatureBase <feature>5__3; //Field offset: 0x40

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
		public <DownloadDependenciesIfNeeded>d__38(int <>1__state) { }

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
	private sealed class <GetAddressablesData>d__35 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AddressablesManager <>4__this; //Field offset: 0x20
		private <>c__DisplayClass35_0 <>8__1; //Field offset: 0x28

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
		public <GetAddressablesData>d__35(int <>1__state) { }

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
	private static AddressablesManager <Instance>k__BackingField; //Field offset: 0x0
	public const int ADDRESSABLES_VERSION = 18; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<AddressablesResponse> OnGetAddressablesDataAction; //Field offset: 0x8
	[CompilerGenerated]
	private static Action OnInitializedAction; //Field offset: 0x10
	public static readonly List<AddressablesFeatureBase> Features; //Field offset: 0x18
	[CompilerGenerated]
	private static string <URL>k__BackingField; //Field offset: 0x20
	private bool _isInitialized; //Field offset: 0x20
	private bool _isGettingData; //Field offset: 0x21
	private bool _isDownloadingDependencies; //Field offset: 0x22
	[CompilerGenerated]
	private AddressablesCloudData <DefaultData>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private AddressablesCloudData <LatestData>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private bool <UseFallbacks>k__BackingField; //Field offset: 0x38

	public static event Action<AddressablesResponse> OnGetAddressablesDataAction
	{
		[CompilerGenerated]
		 add { } //Length: 244
		[CompilerGenerated]
		 remove { } //Length: 244
	}

	public static event Action OnInitializedAction
	{
		[CompilerGenerated]
		 add { } //Length: 220
		[CompilerGenerated]
		 remove { } //Length: 220
	}

	public private AddressablesCloudData DefaultData
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private static AddressablesManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 104
	}

	public bool IsReady
	{
		 get { } //Length: 32
	}

	public private AddressablesCloudData LatestData
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private static string URL
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 96
	}

	public private bool UseFallbacks
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	private static AddressablesManager() { }

	public AddressablesManager() { }

	[CompilerGenerated]
	private void <Initialize>b__50_0(AsyncOperationHandle<IResourceLocator> x) { }

	[CompilerGenerated]
	public static void add_OnGetAddressablesDataAction(Action<AddressablesResponse> value) { }

	[CompilerGenerated]
	public static void add_OnInitializedAction(Action value) { }

	private void Awake() { }

	private bool DidLanguageOrCountryChange(string currentLanguageCode, string currentCountryCode) { }

	[IteratorStateMachine(typeof(<DownloadDependenciesIfNeeded>d__38))]
	protected override IEnumerator DownloadDependenciesIfNeeded() { }

	[CompilerGenerated]
	public AddressablesCloudData get_DefaultData() { }

	[CompilerGenerated]
	public static AddressablesManager get_Instance() { }

	public bool get_IsReady() { }

	[CompilerGenerated]
	public AddressablesCloudData get_LatestData() { }

	[CompilerGenerated]
	public static string get_URL() { }

	[CompilerGenerated]
	public bool get_UseFallbacks() { }

	[IteratorStateMachine(typeof(<GetAddressablesData>d__35))]
	private IEnumerator GetAddressablesData() { }

	private List<Object> GetFeaturesParams() { }

	private static string GetKey(string key) { }

	private string GetLastModifiedData() { }

	public void Init() { }

	private void Initialize() { }

	private void OnCloudResponse(AddressablesResponse response) { }

	private void OnDestroy() { }

	public void OnGameResume() { }

	private void OnInitialized() { }

	private void OnReady() { }

	[CompilerGenerated]
	public static void remove_OnGetAddressablesDataAction(Action<AddressablesResponse> value) { }

	[CompilerGenerated]
	public static void remove_OnInitializedAction(Action value) { }

	private void SaveData(Dictionary<String, Object> data) { }

	[CompilerGenerated]
	private void set_DefaultData(AddressablesCloudData value) { }

	[CompilerGenerated]
	private static void set_Instance(AddressablesManager value) { }

	[CompilerGenerated]
	private void set_LatestData(AddressablesCloudData value) { }

	[CompilerGenerated]
	private static void set_URL(string value) { }

	[CompilerGenerated]
	private void set_UseFallbacks(bool value) { }

	private void SetData(Dictionary<String, Object> data, bool setLastModified) { }

	public void SetDefaultData() { }

	private void SetLastModifiedData(string lastModified) { }

	private void TryGetAddressablesData() { }

	private bool TryLoadSavedData(out Dictionary<String, Object>& data) { }

	private void UpdateCatalogs(Action onFinish = null) { }

}

