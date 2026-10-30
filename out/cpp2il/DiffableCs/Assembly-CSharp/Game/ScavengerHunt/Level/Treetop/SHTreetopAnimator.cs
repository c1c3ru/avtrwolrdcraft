namespace Game.ScavengerHunt.Level.Treetop;

public static class SHTreetopAnimator
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass0_0
	{
		public int finishCounter; //Field offset: 0x10
		public Action <>9__0; //Field offset: 0x18
		public Action <>9__2; //Field offset: 0x20

		public <>c__DisplayClass0_0() { }

		internal void <PlayItemsFlyingAway>b__0() { }

		internal void <PlayItemsFlyingAway>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass0_1
	{
		public Vector2 position; //Field offset: 0x10
		public float xStart; //Field offset: 0x18
		public float xEnd; //Field offset: 0x1C
		public Vector2 startPosition; //Field offset: 0x20
		public GameObject obj; //Field offset: 0x28

		public <>c__DisplayClass0_1() { }

		internal void <PlayItemsFlyingAway>b__1(float value) { }

	}

	[CompilerGenerated]
	private sealed class <PlayItemsFlyingAway>d__0 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ScavengerHuntTypeHandler handler; //Field offset: 0x20
		public Transform dropArea; //Field offset: 0x28
		private <>c__DisplayClass0_0 <>8__1; //Field offset: 0x30
		public Action onFinish; //Field offset: 0x38
		private List<Transform> <flyingItems>5__2; //Field offset: 0x40

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
		public <PlayItemsFlyingAway>d__0(int <>1__state) { }

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


	[IteratorStateMachine(typeof(<PlayItemsFlyingAway>d__0))]
	public static IEnumerator PlayItemsFlyingAway(ScavengerHuntTypeHandler handler, Transform dropArea, Action onFinish) { }

}

