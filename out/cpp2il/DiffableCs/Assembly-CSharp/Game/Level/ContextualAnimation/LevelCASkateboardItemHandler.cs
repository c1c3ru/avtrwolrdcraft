namespace Game.Level.ContextualAnimation;

public class LevelCASkateboardItemHandler : LevelCADropAreaHandlerBase
{
	[CompilerGenerated]
	private sealed class <FallCoroutine>d__17 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCASkateboardItemHandler <>4__this; //Field offset: 0x20

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
		public <FallCoroutine>d__17(int <>1__state) { }

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

	private const string TRICK_JUMP_ANIMATION_NAME = "Skateboard_Trick_Jump"; //Field offset: 0x0
	private const string HAND_STAND_ANIMATION_NAME = "Skateboard_Trick_Hand_Stand"; //Field offset: 0x0
	private const string TOUCH_TAIL_ANIMATION_NAME = "Skateboard_Trick_Touch_Tail"; //Field offset: 0x0
	private const string DISMOUNT_ANIMATION_NAME = "Skateboard_Trick_Dismount"; //Field offset: 0x0
	private const string CATCH_BOARD_ANIMATION_NAME = "Skateboard_Catch_Board"; //Field offset: 0x0
	private const string FALL_OFF_ANIMATION_NAME = "Skateboard_Trick_Fall_Off"; //Field offset: 0x0
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x80
	[SerializeField]
	private GameObject _boneFollowerObject; //Field offset: 0x88
	[SerializeField]
	private GameObject _staticSkateboard; //Field offset: 0x90
	[SerializeField]
	protected LevelSkateboardItemHandler _skateboardHandler; //Field offset: 0x98
	[SerializeField]
	protected LevelSkateboardAnimationItemHandler _animationHandler; //Field offset: 0xA0
	private BoneFollower _boneFollower; //Field offset: 0xA8
	private bool _isFalling; //Field offset: 0xB0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB8

	public LevelCASkateboardItemHandler() { }

	[IteratorStateMachine(typeof(<FallCoroutine>d__17))]
	private IEnumerator FallCoroutine() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsRelevantForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

}

