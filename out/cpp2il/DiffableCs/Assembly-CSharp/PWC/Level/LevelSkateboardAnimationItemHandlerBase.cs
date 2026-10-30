namespace PWC.Level;

public class LevelSkateboardAnimationItemHandlerBase : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public LevelSkateboardAnimationItemHandlerBase <>4__this; //Field offset: 0x10
		public string clipName; //Field offset: 0x18

		public <>c__DisplayClass16_0() { }

		internal void <PlaySound>b__0() { }

	}

	internal enum SkateboardType
	{
		Skateboard = 0,
		HoverBoard = 1,
		RollerSkates = 2,
		Cart = 3,
		Scooter = 4,
		Bicycle = 5,
		Ski = 6,
		Snowboard = 7,
		SnowSled = 8,
	}

	[SerializeField]
	public SkateboardType _skateboardType; //Field offset: 0x20
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x28
	protected ILevelAvatar _currentCharacter; //Field offset: 0x30
	protected string startRailAnimation; //Field offset: 0x38
	private bool isSoundKicking; //Field offset: 0x40
	private int _soundTweenId; //Field offset: 0x44

	public ILevelAvatar CurrentCharacter
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public LevelSkateboardAnimationItemHandlerBase() { }

	public override void EndBoneFollower() { }

	public ILevelAvatar get_CurrentCharacter() { }

	public bool IsRampEnvironmentFit(Environment rampEnvironment) { }

	protected void OnRailingAnimationStart(TrackEntry trackEntry) { }

	public override void PlayMogglesAnimation(bool isStart) { }

	public override void PlayRailAnimation(bool isStart) { }

	public void PlaySound(string clipName, float delay = 0) { }

	public override void PlaySuitableIdle(SkatingMode mode, bool isAdd = false) { }

	public void PlaySuitableSound(SkatingMode mode) { }

	public void set_CurrentCharacter(ILevelAvatar value) { }

	public void SetSkateboardType(SkateboardType type) { }

	public override void StartBoneFollower(ILevelAvatar avatar) { }

}

