namespace SimpleUI;

public sealed class Scheduler : UnitySingleton<Scheduler>
{
	[CompilerGenerated]
	private sealed class <DoUntilTask>d__16 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public YieldInstruction waitTime; //Field offset: 0x20
		public Action task; //Field offset: 0x28
		public Func<Boolean> endcondition; //Field offset: 0x30
		public Scheduler <>4__this; //Field offset: 0x38

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
		public <DoUntilTask>d__16(int <>1__state) { }

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
	private sealed class <DoWhileTask>d__15 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public YieldInstruction waitTime; //Field offset: 0x20
		public Func<Boolean> condition; //Field offset: 0x28
		public Action task; //Field offset: 0x30
		public Func<Boolean> endcondition; //Field offset: 0x38
		public Scheduler <>4__this; //Field offset: 0x40

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
		public <DoWhileTask>d__15(int <>1__state) { }

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
	private sealed class <ForEachTask>d__18 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x0
		private object <>2__current; //Field offset: 0x0
		public IList<T> elements; //Field offset: 0x0
		public Action<T> task; //Field offset: 0x0
		public YieldInstruction wait; //Field offset: 0x0
		public Action OnFinished; //Field offset: 0x0
		private int <i>5__2; //Field offset: 0x0
		private int <elementsCount>5__3; //Field offset: 0x0

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
		public <ForEachTask>d__18`1(int <>1__state) { }

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
	private sealed class <ForEachTaskNonLinear>d__19 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x0
		private object <>2__current; //Field offset: 0x0
		public IList<T> elements; //Field offset: 0x0
		public AnimationCurve interpolation; //Field offset: 0x0
		public float averageTime; //Field offset: 0x0
		public Action<T> task; //Field offset: 0x0
		public Action OnFinished; //Field offset: 0x0
		private int <i>5__2; //Field offset: 0x0
		private int <elementsCount>5__3; //Field offset: 0x0

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
		public <ForEachTaskNonLinear>d__19`1(int <>1__state) { }

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
	private sealed class <Task>d__13 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public int currentFrame; //Field offset: 0x20
		public Action task; //Field offset: 0x28
		public int frameAmount; //Field offset: 0x30
		public Scheduler <>4__this; //Field offset: 0x38

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
		public <Task>d__13(int <>1__state) { }

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
	private sealed class <Task>d__14 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public WaitForSeconds wait; //Field offset: 0x20
		public Action task; //Field offset: 0x28
		public int nrExecutions; //Field offset: 0x30
		public Scheduler <>4__this; //Field offset: 0x38

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
		public <Task>d__14(int <>1__state) { }

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
	private sealed class <WatchTask>d__17 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public YieldInstruction wait; //Field offset: 0x20
		public Func<Boolean> condition; //Field offset: 0x28
		public Action callbackWhenTrue; //Field offset: 0x30
		public bool endWhenTrue; //Field offset: 0x38
		public Scheduler <>4__this; //Field offset: 0x40

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
		public <WatchTask>d__17(int <>1__state) { }

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


	public Scheduler() { }

	public static Coroutine DoForeach(IList<T> elements, Action<T> task, float interval = 1, Action OnFinished = null) { }

	public static Coroutine DoForeach(IList<T> elements, Action<T> task, AnimationCurve customStagger, float averageTime = 1, Action OnFinished = null) { }

	public static Coroutine DoInFuture(Action task, float delay = 1) { }

	public static Coroutine DoUntil(Action task, Func<Boolean> endCondition) { }

	public static Coroutine DoUntil(Action task, Func<Boolean> endCondition, float interval) { }

	[IteratorStateMachine(typeof(<DoUntilTask>d__16))]
	private IEnumerator DoUntilTask(Action task, Func<Boolean> endcondition, YieldInstruction waitTime) { }

	public static Coroutine DoWhen(Func<Boolean> condition, Action callbackWhenTrue, float CheckInterval, bool DoOnlyOnce = true) { }

	public static Coroutine DoWhen(Func<Boolean> condition, Action callbackWhenTrue, bool DoOnlyOnce = true) { }

	public static Coroutine DoWhile(Func<Boolean> condition, Action task, Func<Boolean> endCondition) { }

	public static Coroutine DoWhile(Func<Boolean> condition, Action task, Func<Boolean> endCondition, float interval) { }

	[IteratorStateMachine(typeof(<DoWhileTask>d__15))]
	private IEnumerator DoWhileTask(Func<Boolean> condition, Action task, Func<Boolean> endcondition, YieldInstruction waitTime) { }

	public static void EndTask(Coroutine cor) { }

	[IteratorStateMachine(typeof(<ForEachTask>d__18`1))]
	private IEnumerator ForEachTask(IList<T> elements, Action<T> task, YieldInstruction wait, Action OnFinished = null) { }

	[IteratorStateMachine(typeof(<ForEachTaskNonLinear>d__19`1))]
	private IEnumerator ForEachTaskNonLinear(IList<T> elements, Action<T> task, AnimationCurve interpolation, float averageTime, Action OnFinished = null) { }

	public static Coroutine Repeat(Action task, float interval = 1, int NumberOfExecutions = -1) { }

	public static Coroutine RepeatEveryOtherFrame(Action Task, int FrameToExecuteOn) { }

	public static Coroutine RepeatIndefinitely(Action task, float interval = 1) { }

	[IteratorStateMachine(typeof(<Task>d__13))]
	private IEnumerator Task(Action task, int frameAmount, int currentFrame) { }

	[IteratorStateMachine(typeof(<Task>d__14))]
	private IEnumerator Task(Action task, WaitForSeconds wait, int nrExecutions) { }

	[IteratorStateMachine(typeof(<WatchTask>d__17))]
	private IEnumerator WatchTask(Func<Boolean> condition, Action callbackWhenTrue, YieldInstruction wait, bool endWhenTrue = true) { }

}

