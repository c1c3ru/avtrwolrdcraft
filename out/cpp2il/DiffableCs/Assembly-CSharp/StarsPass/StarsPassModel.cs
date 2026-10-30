namespace StarsPass;

public class StarsPassModel
{
	[CompilerGenerated]
	private static StarsPassModel <Current>k__BackingField; //Field offset: 0x0
	private const string LOCAL_STATE_PROFILE_ID_KEY = "StarsPass_LocalStateProfileId"; //Field offset: 0x0
	private const string LOCAL_STATE_CLOUD_ID_KEY = "StarsPass_LocalStateCloudId"; //Field offset: 0x0
	[CompilerGenerated]
	private static Action OnChanged; //Field offset: 0x8
	private static string _localStateProfileId; //Field offset: 0x10
	private static string _localStateCloudId; //Field offset: 0x18
	[CompilerGenerated]
	private int <TotalStars>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private MilestoneData[] <Milestones>k__BackingField; //Field offset: 0x18

	public static event Action OnChanged
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	public private static StarsPassModel Current
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public static MilestoneData[] MilestoneDatas
	{
		 get { } //Length: 28
	}

	public private MilestoneData[] Milestones
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private int TotalStars
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	private StarsPassModel(LoyaltyPassMilestone[] serverMilestones, int totalStars) { }

	[CompilerGenerated]
	public static void add_OnChanged(Action value) { }

	private void BuildMilestones(LoyaltyPassMilestone[] serverMilestones) { }

	public static StarsPassModel EnsureInitialized() { }

	private static void EnsureLocalStateMatchesAccount() { }

	[CompilerGenerated]
	public static StarsPassModel get_Current() { }

	public static MilestoneData[] get_MilestoneDatas() { }

	[CompilerGenerated]
	public MilestoneData[] get_Milestones() { }

	[CompilerGenerated]
	public int get_TotalStars() { }

	public static StarsProgress GetProgress(int totalStars) { }

	public static StarsProgress GetStarsProgress() { }

	public static MilestoneStatus GetStatusAtTotal(int index, int total) { }

	public static int GetTotalStars() { }

	public static bool HasClaimableGift() { }

	public static bool HasClaimableGiftAtTotal(int total) { }

	private static bool HasLocalStateIdChanged(string prefsKey, ref string localStateId, string currentId) { }

	public static void InitializeFromStore() { }

	public static bool IsAllGiftsClaimed() { }

	public static bool IsOneClaimableGiftRemaining() { }

	public static bool IsStarsClaimable() { }

	public void MarkClaimed(int index) { }

	private static void MergeClaimedFrom(StarsPassModel previous) { }

	public static void RefreshFromServer() { }

	[CompilerGenerated]
	public static void remove_OnChanged(Action value) { }

	[CompilerGenerated]
	private static void set_Current(StarsPassModel value) { }

	[CompilerGenerated]
	private void set_Milestones(MilestoneData[] value) { }

	[CompilerGenerated]
	private void set_TotalStars(int value) { }

	private static void SyncTotal() { }

}

