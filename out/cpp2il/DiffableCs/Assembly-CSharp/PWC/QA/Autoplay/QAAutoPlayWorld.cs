namespace PWC.QA.Autoplay;

public class QAAutoPlayWorld
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public WorldBuildingType buildingType; //Field offset: 0x10

		public <>c__DisplayClass5_0() { }

		internal bool <RunCoroutine>b__0(WorldBuilding x) { }

	}

	[CompilerGenerated]
	private sealed class <RunCoroutine>d__5 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public QAAutoPlayWorld <>4__this; //Field offset: 0x20
		private List<WorldBuilding> <buildings>5__2; //Field offset: 0x28
		private WorldBuilding <building>5__3; //Field offset: 0x30
		private WorldBuildingLevel[] <>7__wrap3; //Field offset: 0x38
		private int <>7__wrap4; //Field offset: 0x40

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
		public <RunCoroutine>d__5(int <>1__state) { }

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

	private readonly QAAutoPlayManager _manager; //Field offset: 0x10
	private readonly WorldBuildingType[] _allWorldBuildings; //Field offset: 0x18
	private List<WorldBuildingType> _buildingsToPlay; //Field offset: 0x20

	public QAAutoPlayWorld(QAAutoPlayManager manager) { }

	public void Run() { }

	[IteratorStateMachine(typeof(<RunCoroutine>d__5))]
	private IEnumerator RunCoroutine() { }

}

