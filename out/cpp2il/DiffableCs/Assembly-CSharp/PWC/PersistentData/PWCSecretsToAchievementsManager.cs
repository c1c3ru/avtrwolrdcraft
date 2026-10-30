namespace PWC.PersistentData;

public class PWCSecretsToAchievementsManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public PWCSecretsToAchievementsManager <>4__this; //Field offset: 0x10
		public Action<Int32> OnFinish; //Field offset: 0x18

		public <>c__DisplayClass13_0() { }

		internal void <GetKittyBankBalance>b__0(int x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass15_0
	{
		public PWCSecretsToAchievementsManager <>4__this; //Field offset: 0x10
		public LevelItem item; //Field offset: 0x18

		public <>c__DisplayClass15_0() { }

		internal void <InstantiateBigPrizeGift>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public Action<Int32> OnFinish; //Field offset: 0x10

		public <>c__DisplayClass18_0() { }

		internal void <GetTotalWorthOfPendingAchievements>b__0(List<AWAAchievementWorth> achievementWorthList) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass22_0
	{
		public LevelItem item; //Field offset: 0x10

		public <>c__DisplayClass22_0() { }

		internal void <ReleaseItemInLevel>g__OnItemStartFall|0(LevelDropArea dropArea) { }

	}

	[CompilerGenerated]
	private static PWCSecretsToAchievementsManager <Instance>k__BackingField; //Field offset: 0x0
	private const float CAMERA_DEAD_ZONE_RATIO = 0,6; //Field offset: 0x0
	public static Action<HuntData, AchievementData> OnAchievementSolvedAction; //Field offset: 0x8
	private bool _isDataDirty; //Field offset: 0x20
	private int _kittyBankBalance; //Field offset: 0x24

	public private static PWCSecretsToAchievementsManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public PWCSecretsToAchievementsManager() { }

	public void AddCoinsToBank(int coins) { }

	private void Awake() { }

	private static void FocusCameraOnItemIfOffCenter(float itemXPosition) { }

	[CompilerGenerated]
	public static PWCSecretsToAchievementsManager get_Instance() { }

	public void GetKittyBankBalance(Action<Int32> OnFinish) { }

	public static void GetTotalWorthOfPendingAchievements(Action<Int32> OnFinish) { }

	private void InstantiateBigPrizeGift(int coins, string achievementGuid, PDPrefabReference reference, float offset = 0) { }

	private void InstantiateCoinGift(int coins, string achievementGuid, float offset = 0) { }

	private void InstantiateItemGift(PDPrefabReference reference, float offset = 0) { }

	private void OnDestroy() { }

	private void OnHuntFinish(HuntData data) { }

	private void OnSecretSolvedAction(LevelType type, SecretData data) { }

	private void OnUserSync(SyncType type) { }

	private void ReleaseItemInLevel(LevelItem item) { }

	public void ResetBankBalance() { }

	public void ResetHunt(HuntData hunt) { }

	[CompilerGenerated]
	private static void set_Instance(PWCSecretsToAchievementsManager value) { }

	private void SetDataDirty() { }

}

