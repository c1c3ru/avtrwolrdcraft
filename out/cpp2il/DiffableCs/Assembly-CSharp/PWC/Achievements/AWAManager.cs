namespace PWC.Achievements;

public class AWAManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<List`1<AWAAchievementWorth>> <>9__20_0; //Field offset: 0x8
		public static Func<AWAAchievementWorth, String> <>9__25_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal string <ClaimAchievements>b__25_1(AWAAchievementWorth x) { }

		internal void <TryClaimPendingAchievements_OnSystemEvent>b__20_0(List<AWAAchievementWorth> claimedList) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public AWAManager <>4__this; //Field offset: 0x10
		public Action<List`1<AWAAchievementWorth>> onFinish; //Field offset: 0x18

		public <>c__DisplayClass24_0() { }

		internal void <GetAchievementsWorth>b__0(AWACloudWorthResponse response) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass25_0
	{
		public AWAManager <>4__this; //Field offset: 0x10
		public HashSet<String> idsAsHashSet; //Field offset: 0x18
		public Action<List`1<AWAAchievementWorth>> onFinish; //Field offset: 0x20

		public <>c__DisplayClass25_0() { }

		internal void <ClaimAchievements>b__0(AWACloudClaimResponse response) { }

	}

	[CompilerGenerated]
	private sealed class <Start>d__12 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AWAManager <>4__this; //Field offset: 0x20

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
		public <Start>d__12(int <>1__state) { }

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

	public static Action<List`1<AWAAchievementWorth>> OnAchievementsClaimedAction; //Field offset: 0x0
	[CompilerGenerated]
	private static AWAManager <Instance>k__BackingField; //Field offset: 0x8
	private AWADeviceData _deviceData; //Field offset: 0x20
	private bool _isCouldInProgress; //Field offset: 0x28
	public bool _isReady; //Field offset: 0x29
	public bool isNeedToGoToStoreAfterUserLinkWindow; //Field offset: 0x2A

	public private static AWAManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public AWAManager() { }

	public bool AddAchievementsToClaim(HashSet<String> ids) { }

	public bool AddAchievementToClaim(string id, out string hash) { }

	private bool AssertCloudOperation() { }

	private void Awake() { }

	public bool CanClaimPendingAchievements() { }

	public void ClaimAchievements(Dictionary<String, String> ids, Action<List`1<AWAAchievementWorth>> onFinish) { }

	[CompilerGenerated]
	public static AWAManager get_Instance() { }

	public void GetAchievementsWorth(Dictionary<String, String> ids, Action<List`1<AWAAchievementWorth>> onFinish) { }

	public void GetAchievementWorth(string id, Action<List`1<AWAAchievementWorth>> onFinish) { }

	public void GetPendingAchievementsWorth(Action<List`1<AWAAchievementWorth>> onFinish) { }

	public void GoToStoreIfNeededAndTryClaimPendingAchievements() { }

	public bool HasPendingAchievements() { }

	public bool IsAllPendingAchievementsClaimedAlready() { }

	public bool IsInPendingAchievements(string id) { }

	private void OnDestroy() { }

	[CompilerGenerated]
	private static void set_Instance(AWAManager value) { }

	[IteratorStateMachine(typeof(<Start>d__12))]
	private IEnumerator Start() { }

	public void TryClaimPendingAchievements(Action<List`1<AWAAchievementWorth>> onFinish) { }

	private void TryClaimPendingAchievements_OnSystemEvent() { }

}

