namespace PWC.Level.Water;

public class LevelWaterAreaStationaryItemHandler : LevelWaterAreaItemHandlerBase
{
	[CompilerGenerated]
	private sealed class <InWaterRoutineCoroutine>d__6 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelWaterAreaStationaryItemHandler <>4__this; //Field offset: 0x20
		private bool <cachedIsInDeepWater>5__2; //Field offset: 0x28

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
		public <InWaterRoutineCoroutine>d__6(int <>1__state) { }

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
	private bool _initChildrenLevelItems; //Field offset: 0x5C
	private Renderer _renderer; //Field offset: 0x60

	public LevelWaterAreaStationaryItemHandler() { }

	private void Awake() { }

	private void Init() { }

	[IteratorStateMachine(typeof(<InWaterRoutineCoroutine>d__6))]
	private IEnumerator InWaterRoutineCoroutine() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private bool ShouldShowWaterLine() { }

	private void SyncWaterLine() { }

	private void SyncWaterPosition() { }

}

