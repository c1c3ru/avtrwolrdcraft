namespace Game.Level;

public class LevelCursedMirrorItemHandler : MonoBehaviour, ILevelSpawnDuringGameplay
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public GameObject spider; //Field offset: 0x10
		public GameObject web; //Field offset: 0x18
		public LevelCursedMirrorItemHandler <>4__this; //Field offset: 0x20
		public Action <>9__2; //Field offset: 0x28
		public Action <>9__1; //Field offset: 0x30

		public <>c__DisplayClass11_0() { }

		internal void <TweenRandomSpider>b__0() { }

		internal void <TweenRandomSpider>b__1() { }

		internal void <TweenRandomSpider>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <HuntedSequenceCoroutine>d__10 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCursedMirrorItemHandler <>4__this; //Field offset: 0x20

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
		public <HuntedSequenceCoroutine>d__10(int <>1__state) { }

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
	private GameObject[] _webs; //Field offset: 0x20
	[SerializeField]
	private GameObject[] _ghosts; //Field offset: 0x28
	private bool _didOnReadyPostLoad; //Field offset: 0x30

	public LevelCursedMirrorItemHandler() { }

	[CompilerGenerated]
	private void <TweenRandomGhost>b__12_0() { }

	private void Awake() { }

	private void EnsureOnReadyPostLoad() { }

	[IteratorStateMachine(typeof(<HuntedSequenceCoroutine>d__10))]
	private IEnumerator HuntedSequenceCoroutine() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnReadyPostLoad() { }

	public override void OnSpawnDuringGameplay() { }

	private void StartAnimationSequence() { }

	private void TweenRandomGhost() { }

	private void TweenRandomSpider() { }

}

