namespace PWC.Achievements;

public static class AWACloudBridge
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass0_0
	{
		public string op; //Field offset: 0x10
		public Action<AWACloudWorthResponse> onFinish; //Field offset: 0x18

		public <>c__DisplayClass0_0() { }

		internal void <GetAchievementsWorth>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_0
	{
		public Dictionary<String, String> ids; //Field offset: 0x10
		public Action<AWACloudClaimResponse> onFinish; //Field offset: 0x18

		public <>c__DisplayClass1_0() { }

		internal void <ClaimAchievements>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public string op; //Field offset: 0x10
		public Action<AWACloudClaimResponse> onFinish; //Field offset: 0x18

		public <>c__DisplayClass2_0() { }

		internal void <ClaimAchievementsImplement>b__0(string responseText) { }

	}


	public static void ClaimAchievements(Dictionary<String, String> ids, Action<AWACloudClaimResponse> onFinish) { }

	private static void ClaimAchievementsImplement(Dictionary<String, String> ids, string integrityToken, Action<AWACloudClaimResponse> onFinish) { }

	public static void GetAchievementsWorth(Dictionary<String, String> ids, Action<AWACloudWorthResponse> onFinish) { }

}

