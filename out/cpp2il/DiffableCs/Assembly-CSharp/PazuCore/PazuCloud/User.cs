namespace PazuCore.PazuCloud;

public static class User
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<RegisterDeviceResponse> <>9__37_1; //Field offset: 0x8
		public static Action<Response> <>9__37_2; //Field offset: 0x10
		public static Action<ClientStateResponse> <>9__37_3; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal void <OnInitLoop>b__37_1(RegisterDeviceResponse response) { }

		internal void <OnInitLoop>b__37_2(Response response) { }

		internal void <OnInitLoop>b__37_3(ClientStateResponse response) { }

	}

	internal static class Keys
	{
		public const string DEVICE_TOKEN = "v2_device_token"; //Field offset: 0x0
		public const string USER_TYPE = "user_type"; //Field offset: 0x0
		public const string INTEGRITY_TOKEN = "integrity_token"; //Field offset: 0x0
		public const string DEPRICATED_USER_JWT_PASSPHRASE = "user_jwt_passphrase"; //Field offset: 0x0
		public const string DEPRICATED_USER_TOKEN = "user_token"; //Field offset: 0x0
		public const string DEPRICATED_DEVICE_TOKEN = "device_token"; //Field offset: 0x0
		public const string OFFLINE_TIME = "offlineTime"; //Field offset: 0x0
		public const string PAZU_CURRENCY = "pazu_currency"; //Field offset: 0x0
		public const string PAZU_CLOUD_ID = "pazu_cloud_id"; //Field offset: 0x0
		public const string IS_AVATAR_PASS_SUBSCRIBER = "is_avatar_pass_subscriber"; //Field offset: 0x0
		public const string IS_AVATAR_PASS_ACTIVE_SUBSCRIPTION = "is_avatar_pass_active_subscription"; //Field offset: 0x0
		public const string IS_ACTIVE_DEVICE = "is_active_device"; //Field offset: 0x0
		public const string IS_ACTIVE_SUBSCRIPTION = "is_active_subscription"; //Field offset: 0x0
		public const string ACCESS_TOKEN = "v2_access_token"; //Field offset: 0x0
		public const string JWT_PASSPHRASE = "v2_jwt_passphrase"; //Field offset: 0x0
		public const string DID_REGISTER_TO_AVATAR_ID = "did_register_to_avatar_id"; //Field offset: 0x0
		public const string LOYALTY_POINTS = "pazu_loyalty_points"; //Field offset: 0x0

	}

	internal enum SyncType
	{
		VerifyReceipt = 0,
		GetClientState = 1,
		Login = 2,
		Init = 3,
		Signup = 4,
		Signout = 5,
		TimeBasedLock = 6,
	}

	internal enum UserType
	{
		None = 0,
		Anon = 1,
		Signed = 2,
	}

	private const string TRUE = "1"; //Field offset: 0x0
	private const string FALSE = "0"; //Field offset: 0x0
	[CompilerGenerated]
	private static bool <IsInitInProgress>k__BackingField; //Field offset: 0x0
	private static int _initSafeCounter; //Field offset: 0x4
	private static bool _shouldCheckForUserMigration; //Field offset: 0x8
	[CompilerGenerated]
	private static bool <IsGoogleIntegrityTokenRequired>k__BackingField; //Field offset: 0x9
	[CompilerGenerated]
	private static HashSet<Int32> <InstalledGames>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private static Action<SyncType> OnSyncAction; //Field offset: 0x18
	[CompilerGenerated]
	private static bool <IsReadyForUserSpecificData>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private static long <ServerTimeFromLastClientState>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private static long <LocalTimeFromLastClientState>k__BackingField; //Field offset: 0x30

	public static event Action<SyncType> OnSyncAction
	{
		[CompilerGenerated]
		 add { } //Length: 244
		[CompilerGenerated]
		 remove { } //Length: 244
	}

	public private static HashSet<Int32> InstalledGames
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 96
	}

	public private static bool IsGoogleIntegrityTokenRequired
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 96
	}

	public private static bool IsInitInProgress
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 96
	}

	public private static bool IsReadyForUserSpecificData
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 96
	}

	public private static long LocalTimeFromLastClientState
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 92
	}

	public private static long ServerTimeFromLastClientState
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 92
	}

	private static User() { }

	[CompilerGenerated]
	internal static void <OnInitLoop>g__FinishInit|37_0() { }

	[CompilerGenerated]
	public static void add_OnSyncAction(Action<SyncType> value) { }

	public static bool CanUseCloud() { }

	public static void DeleteUserData() { }

	public static bool DidRegisterToAvatarId() { }

	public static void ForceSyncEvent(SyncType syncType) { }

	[CompilerGenerated]
	public static HashSet<Int32> get_InstalledGames() { }

	[CompilerGenerated]
	public static bool get_IsGoogleIntegrityTokenRequired() { }

	[CompilerGenerated]
	public static bool get_IsInitInProgress() { }

	[CompilerGenerated]
	public static bool get_IsReadyForUserSpecificData() { }

	[CompilerGenerated]
	public static long get_LocalTimeFromLastClientState() { }

	[CompilerGenerated]
	public static long get_ServerTimeFromLastClientState() { }

	public static string GetAccessToken() { }

	private static string GetDepricatedActiveDeviceKey() { }

	public static string GetDeviceToken() { }

	public static string GetFullVersionKey() { }

	public static string GetJwtPassphrase() { }

	public static int GetLoyaltyPoints() { }

	public static int GetPazuCurrency() { }

	public static UserType GetUserType() { }

	public static string GetUserUUID() { }

	public static bool HasAccessToken() { }

	private static bool HasDepricatedUserData() { }

	public static bool HasDeviceToken() { }

	public static bool HasIntegrityToken() { }

	public static bool HasJwtPassPhrase() { }

	public static void InitIfNeeded() { }

	public static bool IsActiveDevice() { }

	public static bool IsAvatarPassSubscriber() { }

	public static bool IsAvatarPassSubscriptionActive() { }

	public static bool IsEmailValid(string email) { }

	public static bool IsFreeTrialAvailable() { }

	private static bool IsFreeTrialRedeemed() { }

	public static bool IsFullVersion() { }

	public static bool IsLocked() { }

	public static bool IsPasswordValid(string password) { }

	public static bool IsSignedInWithNonAnonUser() { }

	public static bool IsSubscriber() { }

	public static bool IsSubscriptionActive() { }

	public static bool IsTrialPeriod() { }

	public static void OnBuyProductSucceeded() { }

	private static void OnClientStateReceived(ClientStateResponse response) { }

	public static void OnCloudSyncedWithClientChanges() { }

	public static void OnGetClientState(ClientStateResponse response) { }

	private static void OnInitLoop() { }

	public static void OnLogin() { }

	public static void OnRestoreProductsSucceeded() { }

	public static void OnSignout() { }

	public static void OnSignup() { }

	[CompilerGenerated]
	public static void remove_OnSyncAction(Action<SyncType> value) { }

	public static void ResetDevice() { }

	[CompilerGenerated]
	private static void set_InstalledGames(HashSet<Int32> value) { }

	[CompilerGenerated]
	private static void set_IsGoogleIntegrityTokenRequired(bool value) { }

	[CompilerGenerated]
	private static void set_IsInitInProgress(bool value) { }

	[CompilerGenerated]
	private static void set_IsReadyForUserSpecificData(bool value) { }

	[CompilerGenerated]
	private static void set_LocalTimeFromLastClientState(long value) { }

	[CompilerGenerated]
	private static void set_ServerTimeFromLastClientState(long value) { }

	public static void SetDevice(string deviceToken, string jwtPassphrase) { }

	private static void SetFullVersion(bool value) { }

	public static void SetLoyaltyPoints(int count) { }

	public static void SetPazuCurrency(int count) { }

	public static void SetUserDataFromCloudResponse(UserDataResponse response) { }

	public static void SetUserType(UserType userType) { }

}

