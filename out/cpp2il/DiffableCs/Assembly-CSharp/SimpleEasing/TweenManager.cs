namespace SimpleEasing;

public sealed class TweenManager : UnitySingleton<TweenManager>
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public Tween t; //Field offset: 0x10

		public <>c__DisplayClass3_0() { }

		internal void <Animate>b__0() { }

		internal void <Animate>b__1() { }

		internal void <Animate>b__2() { }

		internal void <Animate>b__3() { }

		internal void <Animate>b__4() { }

	}

	[CompilerGenerated]
	private sealed class <Animate>d__3 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Tween t; //Field offset: 0x20
		private <>c__DisplayClass3_0 <>8__1; //Field offset: 0x28
		public TweenManager <>4__this; //Field offset: 0x30
		private Action <easeCall>5__2; //Field offset: 0x38

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
		public <Animate>d__3(int <>1__state) { }

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
	private sealed class <Chain>d__4 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public IEnumerator[] enumerators; //Field offset: 0x20
		public TweenManager <>4__this; //Field offset: 0x28
		private int <j>5__2; //Field offset: 0x30
		private int <enumeratorsLength>5__3; //Field offset: 0x34

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
		public <Chain>d__4(int <>1__state) { }

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

	private readonly WaitForEndOfFrame wait; //Field offset: 0x20

	public TweenManager() { }

	[IteratorStateMachine(typeof(<Animate>d__3))]
	private IEnumerator Animate(Tween t) { }

	[IteratorStateMachine(typeof(<Chain>d__4))]
	private IEnumerator Chain(IEnumerator[] enumerators) { }

	public Coroutine ChainTweens(Tween[] tweens) { }

	private void CheckRepeat(Tween t) { }

	public static void Dispose() { }

	public Coroutine PlayTween(Tween t) { }

	public void StopAllTweens() { }

	public void StopAndReleaseTween(Tween tween) { }

	public void StopTween(Coroutine cor) { }

}

