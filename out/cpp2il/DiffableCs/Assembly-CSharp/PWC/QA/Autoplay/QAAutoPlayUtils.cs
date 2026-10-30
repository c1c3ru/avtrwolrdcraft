namespace PWC.QA.Autoplay;

public static class QAAutoPlayUtils
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__8_0; //Field offset: 0x8
		public static Func<MonoBehaviour, Boolean> <>9__16_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal bool <GetVisibleObjects>b__16_0(MonoBehaviour x) { }

		internal void <SetPointerIndicatorPosition>b__8_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__10
	{
		public static readonly <>c__10<T> <>9; //Field offset: 0x0
		public static EventFunction<T> <>9__10_1; //Field offset: 0x0

		private static <>c__10`1() { }

		public <>c__10`1() { }

		internal void <IsGameObjectInteractable>b__10_1(T _, BaseEventData _) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public Vector2 pointerPosition; //Field offset: 0x10
		public Camera camera; //Field offset: 0x18
		public GameObject gameObject; //Field offset: 0x20
		public Vector2 destination; //Field offset: 0x28
		public float durationInTarget; //Field offset: 0x30
		public PointerEventData eventData; //Field offset: 0x38
		public DragDropItemBase dragItem; //Field offset: 0x40
		public bool didComplete; //Field offset: 0x48
		public Action <>9__4; //Field offset: 0x50

		public <>c__DisplayClass12_0() { }

		internal void <DragGameObjectTo>b__1(Vector2 value) { }

		internal void <DragGameObjectTo>b__2() { }

		internal bool <DragGameObjectTo>b__3() { }

		internal void <DragGameObjectTo>b__4() { }

		internal bool <DragGameObjectTo>g__TryGetDragItemPosition|0(DragDropItemBase item, out Vector2 outPosition) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public Predicate<MonoBehaviour> condition; //Field offset: 0x10

		public <>c__DisplayClass16_0() { }

		internal bool <GetVisibleObjects>b__1(MonoBehaviour x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass17_0
	{
		public Bounds cameraBounds; //Field offset: 0x0

		public <>c__DisplayClass17_0`1() { }

		internal bool <GetItemsInCameraBounds>b__0(T item) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public bool didComplete; //Field offset: 0x10

		public <>c__DisplayClass3_0() { }

		internal void <MoveCamera>b__0() { }

		internal bool <MoveCamera>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public bool didComplete; //Field offset: 0x10

		public <>c__DisplayClass4_0() { }

		internal void <MoveCameraToTheRight>b__0() { }

		internal bool <MoveCameraToTheRight>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <ClickOnGameObjectWhenPossible>d__2 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public GameObject gameObject; //Field offset: 0x20

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
		public <ClickOnGameObjectWhenPossible>d__2(int <>1__state) { }

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
	private sealed class <DragGameObjectTo>d__12 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public GameObject gameObject; //Field offset: 0x20
		public Vector2 destination; //Field offset: 0x28
		public float durationInTarget; //Field offset: 0x30
		private <>c__DisplayClass12_0 <>8__1; //Field offset: 0x38

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
		public <DragGameObjectTo>d__12(int <>1__state) { }

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
	private sealed class <MoveCamera>d__3 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float amount; //Field offset: 0x20
		public Action onLoopAction; //Field offset: 0x28

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
		public <MoveCamera>d__3(int <>1__state) { }

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
	private sealed class <MoveCameraToTheRight>d__4 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18

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
		public <MoveCameraToTheRight>d__4(int <>1__state) { }

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
	private sealed class <WaitFor>d__5 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float extraTimeToWait; //Field offset: 0x20
		public string stackTrace; //Field offset: 0x28
		public Func<Boolean> condition; //Field offset: 0x30
		private float <safeTimer>5__2; //Field offset: 0x38

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
		public <WaitFor>d__5(int <>1__state) { }

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
	private sealed class <WaitForGameObject>d__7 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public GameObject gameObject; //Field offset: 0x20
		private float <safeTimer>5__2; //Field offset: 0x28

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
		public <WaitForGameObject>d__7(int <>1__state) { }

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
	private sealed class <WaitForObjects>d__6 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x0
		private object <>2__current; //Field offset: 0x0
		public Action<T[]> onComplete; //Field offset: 0x0
		private float <safeTimer>5__2; //Field offset: 0x0

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
		public <WaitForObjects>d__6`1(int <>1__state) { }

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

	private static Transform _pointerIndicator; //Field offset: 0x0
	public const float SAFE_TIMER_LIMIT = 1; //Field offset: 0x0

	[CompilerGenerated]
	internal static List<Vector2> <IsGameObjectInteractable>g__getPointsToTest|10_0(Bounds bounds) { }

	[IteratorStateMachine(typeof(<ClickOnGameObjectWhenPossible>d__2))]
	public static IEnumerator ClickOnGameObjectWhenPossible(GameObject gameObject) { }

	[IteratorStateMachine(typeof(<DragGameObjectTo>d__12))]
	public static IEnumerator DragGameObjectTo(GameObject gameObject, Vector2 destination, float durationInTarget = 0) { }

	public static T FindObject() { }

	public static T[] FindObjects() { }

	public static PointerEventData GetEventData(Vector2 position) { }

	public static T[] GetItemsInCameraBounds(IList<T> collection) { }

	public static T GetRandomItem(IList<T> colleciton) { }

	public static MonoBehaviour[] GetVisibleObjects(Predicate<MonoBehaviour> condition = null) { }

	public static bool IsGameObjectInteractable(GameObject gameObject) { }

	[IteratorStateMachine(typeof(<MoveCamera>d__3))]
	public static IEnumerator MoveCamera(float amount, Action onLoopAction = null) { }

	[IteratorStateMachine(typeof(<MoveCameraToTheRight>d__4))]
	public static IEnumerator MoveCameraToTheRight() { }

	public static void SetPointerIndicatorPosition(Vector2 position, float hideAfterDuration = -1) { }

	public static bool ShouldConsiderObject(GameObject gameObject) { }

	public static bool ShouldConsiderObject(MonoBehaviour monoBehaviour) { }

	public static bool TryClickOnGameObject(GameObject gameObject) { }

	[IteratorStateMachine(typeof(<WaitFor>d__5))]
	public static IEnumerator WaitFor(Func<Boolean> condition, string stackTrace, float extraTimeToWait = 0) { }

	[IteratorStateMachine(typeof(<WaitForGameObject>d__7))]
	private static IEnumerator WaitForGameObject(GameObject gameObject) { }

	[IteratorStateMachine(typeof(<WaitForObjects>d__6`1))]
	public static IEnumerator WaitForObjects(Action<T[]> onComplete) { }

}

