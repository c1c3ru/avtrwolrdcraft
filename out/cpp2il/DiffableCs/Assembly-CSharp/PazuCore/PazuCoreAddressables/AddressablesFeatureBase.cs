namespace PazuCore.PazuCoreAddressables;

public abstract class AddressablesFeatureBase : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass43_0
	{
		public AddressablesFeatureBase <>4__this; //Field offset: 0x10
		public bool showClickBlocker; //Field offset: 0x18
		public Action onFinish; //Field offset: 0x20

		public <>c__DisplayClass43_0() { }

		internal void <PrepareFeature>b__0() { }

		internal void <PrepareFeature>b__1(AsyncOperationHandle<GameObject> handle) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass48_0
	{
		public AddressablesFeatureBase <>4__this; //Field offset: 0x10
		public AddressablesFeatureViewBase viewPrefab; //Field offset: 0x18
		public bool isAddessables; //Field offset: 0x20
		public Action onSuccess; //Field offset: 0x28

		public <>c__DisplayClass48_0() { }

		internal void <TryInstantiateViewImplement>g__OnOrientationFit|0(bool success) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass55_0
	{
		public Action onHandleCompleteAction; //Field offset: 0x10

		public <>c__DisplayClass55_0() { }

		internal void <ReleaseActiveHandleIfNeeded>b__0(AsyncOperationHandle<GameObject> x) { }

	}

	[CompilerGenerated]
	private static AddressablesCloudData <CurrentData>k__BackingField; //Field offset: 0x0
	private string _featureCloudResponseKey; //Field offset: 0x20
	protected string _addressablesLabel; //Field offset: 0x28
	protected float _asyncOperationsTimeout; //Field offset: 0x30
	protected AsyncOperationHandle<GameObject> _activeHandle; //Field offset: 0x38
	private bool _allowLoadBeforeAudioReady; //Field offset: 0x50
	protected AddressablesFeatureViewBase _currentView; //Field offset: 0x58
	private readonly List<String> _audioKeys; //Field offset: 0x60
	[CompilerGenerated]
	private AFCRDHandlersData <AFCRDHandlersData>k__BackingField; //Field offset: 0x68
	[CompilerGenerated]
	private int <DownloadPriority>k__BackingField; //Field offset: 0x70
	[CompilerGenerated]
	private bool <IsPreparing>k__BackingField; //Field offset: 0x74

	public string AddressablesLabel
	{
		 get { } //Length: 8
	}

	public private AFCRDHandlersData AFCRDHandlersData
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public static AddressablesCloudData CurrentData
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		 set { } //Length: 88
	}

	public AddressablesFeatureViewBase CurrentView
	{
		 get { } //Length: 8
	}

	protected string DataFileNameKey
	{
		 get { } //Length: 108
	}

	public private int DownloadPriority
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private bool IsPreparing
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	protected AddressablesFeatureBase() { }

	[CompilerGenerated]
	private void <TryInstantiateView>b__40_0() { }

	[CompilerGenerated]
	private void <TryInstantiateViewFromResources>b__46_0() { }

	[CompilerGenerated]
	private void <TryInstantiateViewFromResources>b__46_1() { }

	protected override bool AllowNonGameScreenOrientation() { }

	protected override void Awake() { }

	public void CreateAnalyticsEvent(String[] items) { }

	private void EnsureAudioClips() { }

	public string get_AddressablesLabel() { }

	[CompilerGenerated]
	public AFCRDHandlersData get_AFCRDHandlersData() { }

	[CompilerGenerated]
	public static AddressablesCloudData get_CurrentData() { }

	public AddressablesFeatureViewBase get_CurrentView() { }

	protected string get_DataFileNameKey() { }

	[CompilerGenerated]
	public int get_DownloadPriority() { }

	[CompilerGenerated]
	public bool get_IsPreparing() { }

	protected abstract string GetFallbackResourcesPath() { }

	protected abstract string GetFeatureCloudResponseKey() { }

	protected abstract string GetFeatureKey() { }

	public override Dictionary<String, Object> GetFeatureParams() { }

	public abstract AddressablesFeatureType GetFeatureType() { }

	private static string GetKey(string key) { }

	private bool HasAllRequiredAudioClips() { }

	public override void Init(bool didChangeVersion) { }

	public override void OnAddressableViewDestroy() { }

	protected override void OnDestroy() { }

	public override void OnGameResumeAfterTryGetAddressablesData() { }

	protected override void OnGetAddressablesData(AddressablesResponse response) { }

	protected override void OnInitialized() { }

	public override void PrepareFeature(bool showClickBlocker, bool useTimeout, Action onFinish = null) { }

	public void ReleaseActiveHandleIfNeeded(Action onHandleCompleteAction) { }

	protected override void SaveData(Dictionary<String, Object> data) { }

	[CompilerGenerated]
	private void set_AFCRDHandlersData(AFCRDHandlersData value) { }

	[CompilerGenerated]
	public static void set_CurrentData(AddressablesCloudData value) { }

	[CompilerGenerated]
	private void set_DownloadPriority(int value) { }

	[CompilerGenerated]
	private void set_IsPreparing(bool value) { }

	protected override void SetData(Dictionary<String, Object> data) { }

	private void SetDefaultData() { }

	public override void TryInstantiateView() { }

	protected override bool TryInstantiateViewFromAddressables(GameObject prefab) { }

	protected override bool TryInstantiateViewFromResources() { }

	private bool TryInstantiateViewImplement(AddressablesFeatureViewBase viewPrefab, bool isAddessables, Action onSuccess = null) { }

	public bool TryLoadPreparedFeature(bool reportHandleProblems) { }

	protected override bool TryLoadSavedData(out Dictionary<String, Object>& data) { }

}

