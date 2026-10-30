namespace Game.Level;

public class LevelHockeyPuckItemHandler : LevelConsumerAreaBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public Vector2 source; //Field offset: 0x10
		public Vector2 destination; //Field offset: 0x18
		public LevelHockeyPuckItemHandler <>4__this; //Field offset: 0x20
		public Vector2 lastPostition; //Field offset: 0x28
		public TargetType targetType; //Field offset: 0x30
		public bool goalKeeperSave; //Field offset: 0x34
		public bool isScore; //Field offset: 0x35
		public LevelAirHockeyGoal goal; //Field offset: 0x38
		public Vector2 vector; //Field offset: 0x40

		public <>c__DisplayClass19_0() { }

		internal void <Shoot>b__0(float t) { }

		internal void <Shoot>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass20_0
	{
		public LevelHockeyPuckItemHandler <>4__this; //Field offset: 0x10
		public Transform parent; //Field offset: 0x18
		public bool didComplete; //Field offset: 0x20
		public float velocityY; //Field offset: 0x24
		public Vector2 position; //Field offset: 0x28
		public Vector2 fallDestination; //Field offset: 0x30
		public int tweenID; //Field offset: 0x38

		public <>c__DisplayClass20_0() { }

		internal void <ScoreInternal>b__0() { }

		internal void <ScoreInternal>b__1() { }

		internal void <ScoreInternal>b__2(float t) { }

	}

	[CompilerGenerated]
	private static Action<LevelHockeyPuckItemHandler, LevelAirHockeyGoal> OnScoreAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<LevelHockeyPuckItemHandler, LevelAirHockeyGoal> OnFailedToScoreAction; //Field offset: 0x8
	[SerializeField]
	private string _hitWallSoundName; //Field offset: 0x58
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x60
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x68
	private bool _isUnderCooldown; //Field offset: 0x70
	private bool _isOnAirHockeyTable; //Field offset: 0x71

	public static event Action<LevelHockeyPuckItemHandler, LevelAirHockeyGoal> OnFailedToScoreAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Action<LevelHockeyPuckItemHandler, LevelAirHockeyGoal> OnScoreAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public bool IsOnAirHockeyTable
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public bool IsUnderCooldown
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public LevelHockeyPuckItemHandler() { }

	[CompilerGenerated]
	private void <OnStrikerHit>b__17_0() { }

	[CompilerGenerated]
	public static void add_OnFailedToScoreAction(Action<LevelHockeyPuckItemHandler, LevelAirHockeyGoal> value) { }

	[CompilerGenerated]
	public static void add_OnScoreAction(Action<LevelHockeyPuckItemHandler, LevelAirHockeyGoal> value) { }

	public bool get_IsOnAirHockeyTable() { }

	public bool get_IsUnderCooldown() { }

	private void MissInternal(Vector2 vector) { }

	public void OnStrikerHit(LevelHockeyStrikerItemHandler levelHockeyStriker) { }

	private void PlaySound(string soundName) { }

	[CompilerGenerated]
	public static void remove_OnFailedToScoreAction(Action<LevelHockeyPuckItemHandler, LevelAirHockeyGoal> value) { }

	[CompilerGenerated]
	public static void remove_OnScoreAction(Action<LevelHockeyPuckItemHandler, LevelAirHockeyGoal> value) { }

	private void ScoreInternal(LevelAirHockeyGoal goal) { }

	public void set_IsOnAirHockeyTable(bool value) { }

	public void set_IsUnderCooldown(bool value) { }

	public void Shoot(LevelAirHockeyGoal goal, TargetType targetType, bool isScore, float arcFactor, bool isRecursiveCall = false, bool goalKeeperShouldAttemptAnimation = true, bool goalKeeperShouldAttemptToStop = true) { }

	private void ShootFromCurrentHolder(TargetType targetType, bool isScore, LevelHockeyStrikerItemHandler levelHockeyStriker) { }

}

