namespace Game.Store;

public class StoreManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<Item> <>9__66_2; //Field offset: 0x8
		public static Func<Boolean> <>9__75_0; //Field offset: 0x10
		public static Predicate<Group> <>9__78_1; //Field offset: 0x18
		public static Action <>9__95_0; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal bool <GetStoreData>b__78_1(Group x) { }

		internal bool <OnClaimItemCloudResponse>b__66_2(Item x) { }

		internal void <ShowRequireAvatarIDMessage>b__95_0() { }

		internal bool <SpawnPackWhenPossible>b__75_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass60_0
	{
		public string sceneName; //Field offset: 0x10
		public StoreManager <>4__this; //Field offset: 0x18

		public <>c__DisplayClass60_0() { }

		internal void <LoadSceneOnClaim>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass66_0
	{
		public string packName; //Field offset: 0x10

		public <>c__DisplayClass66_0() { }

		internal bool <OnClaimItemCloudResponse>b__0(Item x) { }

		internal bool <OnClaimItemCloudResponse>b__1(Item x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass78_0
	{
		public StoreManager <>4__this; //Field offset: 0x10
		public string op; //Field offset: 0x18
		public Action onSuccess; //Field offset: 0x20

		public <>c__DisplayClass78_0() { }

		internal void <GetStoreData>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass87_0
	{
		public StoreManager <>4__this; //Field offset: 0x10
		public string op; //Field offset: 0x18
		public Action<StoreClaimItemCloudResponse> onSuccess; //Field offset: 0x20
		public Func<Response, Boolean> overrideOnFailure; //Field offset: 0x28

		public <>c__DisplayClass87_0() { }

		internal void <ClaimItemInternal>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass88_0
	{
		public StoreManager <>4__this; //Field offset: 0x10
		public string productName; //Field offset: 0x18
		public string itemGuid; //Field offset: 0x20
		public Action<StoreClaimItemCloudResponse> onSuccess; //Field offset: 0x28
		public Action<StoreClaimItemCloudResponse> <>9__2; //Field offset: 0x30

		public <>c__DisplayClass88_0() { }

		internal void <BuyAndClaimItem>b__0() { }

		internal void <BuyAndClaimItem>b__1() { }

		internal void <BuyAndClaimItem>b__2(StoreClaimItemCloudResponse response) { }

	}

	[CompilerGenerated]
	private sealed class <SpawnPackWhenPossible>d__75 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public StoreManager <>4__this; //Field offset: 0x20
		public string sceneName; //Field offset: 0x28
		public Vector2 position; //Field offset: 0x30

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
		public <SpawnPackWhenPossible>d__75(int <>1__state) { }

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
	private sealed class <Start>d__56 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public StoreManager <>4__this; //Field offset: 0x20

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
		public <Start>d__56(int <>1__state) { }

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

	internal enum ErrorCode
	{
		None = 0,
		Deprecated1 = 1,
		Deprecated2 = 2,
		IAPFailed = 3,
		CloudResponseError = 4,
		AlreadyInProgressForBuyAndClaim = 5,
		AlreadyInProgressForClaim = 6,
	}

	internal class PrefabClaimData
	{
		public string packName; //Field offset: 0x10
		public PDPrefab prefab; //Field offset: 0x18
		public string sceneName; //Field offset: 0x20
		public List<PackInBundle> packsInBundle; //Field offset: 0x28

		public PrefabClaimData() { }

	}

	internal sealed class TryOverrideOnClaimSuccessDelegate : MulticastDelegate
	{

		public TryOverrideOnClaimSuccessDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(StoreClaimItemCloudResponse response, ref bool didOverride, AsyncCallback callback, object object) { }

		public override void EndInvoke(ref bool didOverride, IAsyncResult result) { }

		public override void Invoke(StoreClaimItemCloudResponse response, ref bool didOverride) { }

	}

	public const string STATE_FILE_NAME = "StoreState"; //Field offset: 0x0
	private const string AVATAR_PASS_PRODUCT_ID = "game55.subscription.avatarpass"; //Field offset: 0x0
	[CompilerGenerated]
	private static TryOverrideOnClaimSuccessDelegate TryOverrideOnClaimItemSuccessAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action OnCurrencyBalanceChangedPostClaimAction; //Field offset: 0x8
	[CompilerGenerated]
	private static string <SourceValueForClaimCloudRequests>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private static StoreManager <Instance>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private string <ClaimedItemGuidToAddPostClaimProgress>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private PrefabClaimData <ClaimedPrefabData>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private StoreData <CurrentData>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private ClientMessage <CurrentClientMessage>k__BackingField; //Field offset: 0x38
	private bool _isGetStoreDataInProgress; //Field offset: 0x40
	private bool _isClaimInProgress; //Field offset: 0x41
	private long _claimItemWithCouponCallCounterStartTime; //Field offset: 0x48
	private int _claimItemWithCouponCallCounter; //Field offset: 0x50
	private StoreIAPHandle _iapHandle; //Field offset: 0x58
	[CompilerGenerated]
	private string <LastClaimTryProductName>k__BackingField; //Field offset: 0x60
	private Nullable<DateTime> _lastDataDateTime; //Field offset: 0x68
	private StoreState _storeState; //Field offset: 0x78
	private string _lastFinishTransactionsReceiptHash; //Field offset: 0x80

	public static event Action OnCurrencyBalanceChangedPostClaimAction
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	public static event TryOverrideOnClaimSuccessDelegate TryOverrideOnClaimItemSuccessAction
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public private string ClaimedItemGuidToAddPostClaimProgress
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private PrefabClaimData ClaimedPrefabData
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private ClientMessage CurrentClientMessage
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private StoreData CurrentData
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private static StoreManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public bool IsClaimInProgress
	{
		 get { } //Length: 8
	}

	public bool IsGetStoreDataInProgress
	{
		 get { } //Length: 8
	}

	public static bool IsStoreActive
	{
		 get { } //Length: 88
	}

	public private string LastClaimTryProductName
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public static string SourceValueForClaimCloudRequests
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		 set { } //Length: 80
	}

	public StoreState StoreState
	{
		 get { } //Length: 8
	}

	public StoreManager() { }

	[CompilerGenerated]
	private bool <ClaimItemWithCoupon>b__86_0(Response response) { }

	[CompilerGenerated]
	internal static string <SpawnPrefabPostClaimItem>g__GetPackNameWithItemsMenu|76_0(List<PackInBundle> packsInBundle) { }

	[CompilerGenerated]
	private void <TryFinishTransaction>b__98_0(StoreClaimItemCloudResponse response) { }

	[CompilerGenerated]
	public static void add_OnCurrencyBalanceChangedPostClaimAction(Action value) { }

	[CompilerGenerated]
	public static void add_TryOverrideOnClaimItemSuccessAction(TryOverrideOnClaimSuccessDelegate value) { }

	private void AddToClaimedItems(string itemGuid) { }

	private void Awake() { }

	public void BuyAndClaimItem(string itemGuid, string productName, Action<StoreClaimItemCloudResponse> onSuccess = null) { }

	public void ClaimItem(Item itemData, Action<StoreClaimItemCloudResponse> onSuccess = null) { }

	public void ClaimItem(string itemGuid, Action<StoreClaimItemCloudResponse> onSuccess = null) { }

	private void ClaimItemInternal(Dictionary<String, Object> data, string op, Func<Response, Boolean> overrideOnFailure = null, Action<StoreClaimItemCloudResponse> onSuccess = null) { }

	public void ClaimItemWithCoupon(string couponCode) { }

	public void ClaimWithPrompt(Item itemData) { }

	[CompilerGenerated]
	public string get_ClaimedItemGuidToAddPostClaimProgress() { }

	[CompilerGenerated]
	public PrefabClaimData get_ClaimedPrefabData() { }

	[CompilerGenerated]
	public ClientMessage get_CurrentClientMessage() { }

	[CompilerGenerated]
	public StoreData get_CurrentData() { }

	[CompilerGenerated]
	public static StoreManager get_Instance() { }

	public bool get_IsClaimInProgress() { }

	public bool get_IsGetStoreDataInProgress() { }

	public static bool get_IsStoreActive() { }

	[CompilerGenerated]
	public string get_LastClaimTryProductName() { }

	[CompilerGenerated]
	public static string get_SourceValueForClaimCloudRequests() { }

	public StoreState get_StoreState() { }

	public void GetStoreData(Action onSuccess = null) { }

	public void InvalidateCurrentData() { }

	public bool IsAvatarPassSubscriptionActive() { }

	public bool IsDataReady() { }

	private void LoadSceneOnClaim(string sceneName) { }

	public void LoadState() { }

	public void LogState() { }

	private void MigrateStateFileIfNeeded() { }

	private void OnApplicationPause(bool pause) { }

	private void OnClaimItemCloudResponse(string responseText, out StoreClaimItemCloudResponse claimResponse, out bool isAlreadyInClaimedItems) { }

	private void OnClaimItemFailed(ErrorCode errorCode, IAPResult iAPResult = null, Nullable<Int32> subErrorCode = null) { }

	private void OnClaimItemSuccess(StoreClaimItemCloudResponse response) { }

	private void OnDestroy() { }

	private void OnGameProgressLoadedFromCloud() { }

	private void OnIAPEnded(IAPResult result) { }

	private void OnLevelPostInit() { }

	private void OnPreGameProgressSaveToCloud() { }

	private void OnPreSaveProgress(Scene scene) { }

	private void OnResetWorldData() { }

	private bool OnTryClaimItemWithCoupon() { }

	private void OnUGCPostInit() { }

	private void OnUserSync(SyncType syncType) { }

	public bool OverrideCanListenToPurchaseSuccess() { }

	private bool OverrideVerifyReceiptOp(VerifyReceiptActionType actionType, out string op, out Dictionary<String, Object>& extraData) { }

	private bool OverrideVerifyReceiptResponseHandling(VerifyReceiptActionType actionType, string responseText, out Response response) { }

	[CompilerGenerated]
	public static void remove_OnCurrencyBalanceChangedPostClaimAction(Action value) { }

	[CompilerGenerated]
	public static void remove_TryOverrideOnClaimItemSuccessAction(TryOverrideOnClaimSuccessDelegate value) { }

	public void RemoveFromClaimedItems(string itemGuid) { }

	public void SaveDataIfNeeded() { }

	[CompilerGenerated]
	private void set_ClaimedItemGuidToAddPostClaimProgress(string value) { }

	[CompilerGenerated]
	private void set_ClaimedPrefabData(PrefabClaimData value) { }

	[CompilerGenerated]
	private void set_CurrentClientMessage(ClientMessage value) { }

	[CompilerGenerated]
	private void set_CurrentData(StoreData value) { }

	[CompilerGenerated]
	private static void set_Instance(StoreManager value) { }

	[CompilerGenerated]
	private void set_LastClaimTryProductName(string value) { }

	[CompilerGenerated]
	public static void set_SourceValueForClaimCloudRequests(string value) { }

	private void SetNewSkinsInventoryFlags(StoreClaimItemCloudResponse response) { }

	public static void ShowGameUpdateMessageForItem() { }

	public static void ShowRequireAvatarIDMessage(Action onClickAction = null) { }

	private void ShowTooManyAttemptsMessage() { }

	[IteratorStateMachine(typeof(<SpawnPackWhenPossible>d__75))]
	private IEnumerator SpawnPackWhenPossible(string sceneName, Vector2 position) { }

	public PDPrefab SpawnPrefabPostClaimItem(string sceneName, Vector2 position) { }

	[IteratorStateMachine(typeof(<Start>d__56))]
	private IEnumerator Start() { }

	public void TryFinishTransaction() { }

	private void TrySpawnClaimedItemPrefabIfExist() { }

}

