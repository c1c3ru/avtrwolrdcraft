namespace BWYW;

public class PWCSkillManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<SkinData, String> <>9__28_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal string <OnPutClothingStaticAction>b__28_0(SkinData skin) { }

	}

	[CompilerGenerated]
	private sealed class <Init>d__20 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PWCSkillManager <>4__this; //Field offset: 0x20

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
		public <Init>d__20(int <>1__state) { }

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

	public const int FINISHED_TASK_POPUP_DURATION = 5; //Field offset: 0x0
	public const int PROGRESS_TASK_POPUP_DURATION = 2; //Field offset: 0x0
	[CompilerGenerated]
	private static PWCSkillManager <Instance>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private bool <IsDataValid>k__BackingField; //Field offset: 0x20
	private HashSet<String> relevantAnimationsDoneToday; //Field offset: 0x28
	private HashSet<String> relevantClothesWornToday; //Field offset: 0x30
	private BWYWTimedGamePopup _currentActivePopup; //Field offset: 0x38
	private SkillType _currentSkillType; //Field offset: 0x40
	private bool _isInit; //Field offset: 0x44

	public SkillType CurrentSkillType
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public private static PWCSkillManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public private bool IsDataValid
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public PWCSkillManager() { }

	private void Awake() { }

	private void CheckClothesOfCharacter(LevelCharacter character) { }

	public SkillType get_CurrentSkillType() { }

	[CompilerGenerated]
	public static PWCSkillManager get_Instance() { }

	[CompilerGenerated]
	public bool get_IsDataValid() { }

	private void HandlePopup(int taskProgress, int targetCount) { }

	[IteratorStateMachine(typeof(<Init>d__20))]
	private IEnumerator Init() { }

	private void OnAnimationEndStatic(ICATarget target, LevelCAConfig config, string animationName) { }

	private void OnApplicationPause(bool pause) { }

	private void OnAvatarSpawn(ILevelAvatar avatar) { }

	private void OnClaim() { }

	private void OnDestroy() { }

	private void OnNotificationEnd() { }

	private void OnPermanentPostInit() { }

	private void OnPopUpPress() { }

	private void OnPutClothingStaticAction(int id, string skinName) { }

	private void OnResetWorldData() { }

	private void OnSecretSolvedAction(LevelType type, SecretData data) { }

	public void set_CurrentSkillType(SkillType value) { }

	[CompilerGenerated]
	private static void set_Instance(PWCSkillManager value) { }

	[CompilerGenerated]
	private void set_IsDataValid(bool value) { }

	private void ShowPopup(int taskId, int taskProgress, float duration) { }

	private void Start() { }

}

