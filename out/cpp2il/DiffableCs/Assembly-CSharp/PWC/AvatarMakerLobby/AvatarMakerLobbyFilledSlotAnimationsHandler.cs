namespace PWC.AvatarMakerLobby;

public class AvatarMakerLobbyFilledSlotAnimationsHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <PlayAnimationAndWait>d__4 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AvatarMakerLobbyFilledSlotAnimationsHandler <>4__this; //Field offset: 0x20
		public string name; //Field offset: 0x28
		public int repetitions; //Field offset: 0x30
		public ValueTuple<Single, Action>[] actionsAfterDurations; //Field offset: 0x38
		private float <animationDuration>5__2; //Field offset: 0x40
		private float <totalDurations>5__3; //Field offset: 0x44
		private ValueTuple<Single, Action>[] <>7__wrap3; //Field offset: 0x48
		private int <>7__wrap4; //Field offset: 0x50
		private Action <action>5__6; //Field offset: 0x58

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
		public <PlayAnimationAndWait>d__4(int <>1__state) { }

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
	private sealed class <PlayAnimationsInternal>d__3 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AvatarMakerLobbyFilledSlotAnimationsHandler <>4__this; //Field offset: 0x20
		public AnimationsSetParams[] animations; //Field offset: 0x28
		private int <i>5__2; //Field offset: 0x30

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
		public <PlayAnimationsInternal>d__3(int <>1__state) { }

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

	private const int ANIMATION_TRACK = 0; //Field offset: 0x0
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x20
	private Coroutine _currentAnimationCoroutine; //Field offset: 0x28

	public AvatarMakerLobbyFilledSlotAnimationsHandler() { }

	public void LoopAnimation(string name) { }

	[IteratorStateMachine(typeof(<PlayAnimationAndWait>d__4))]
	private IEnumerator PlayAnimationAndWait(string name, int repetitions, ValueTuple<Single, Action>[] actionsAfterDurations) { }

	public void PlayAnimations(AnimationsSetParams[] animations) { }

	[IteratorStateMachine(typeof(<PlayAnimationsInternal>d__3))]
	private IEnumerator PlayAnimationsInternal(AnimationsSetParams[] animations) { }

}

