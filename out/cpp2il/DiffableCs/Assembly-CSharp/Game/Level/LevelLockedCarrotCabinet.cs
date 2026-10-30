namespace Game.Level;

public class LevelLockedCarrotCabinet : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <AnimateLights>d__3 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelLockedCarrotCabinet <>4__this; //Field offset: 0x20
		public Action onAnimationEnd; //Field offset: 0x28
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
		public <AnimateLights>d__3(int <>1__state) { }

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

	[SerializeField]
	private LevelLight[] _lamps; //Field offset: 0x20
	[SerializeField]
	private LevelDoor _door; //Field offset: 0x28

	public LevelLockedCarrotCabinet() { }

	[CompilerGenerated]
	private void <OnSolved>b__2_0() { }

	[IteratorStateMachine(typeof(<AnimateLights>d__3))]
	private IEnumerator AnimateLights(Action onAnimationEnd) { }

	public void OnSolved() { }

}

