namespace Game.Store;

public class StoreButtonPackIndicatorBadge : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public StoreData storeData; //Field offset: 0x10
		public string packName; //Field offset: 0x18

		public <>c__DisplayClass2_0() { }

		internal bool <Init>b__0(Group x) { }

		internal bool <Init>b__1(Item x) { }

	}

	[CompilerGenerated]
	private sealed class <Start>d__1 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public StoreButtonPackIndicatorBadge <>4__this; //Field offset: 0x20
		private CanvasGroup <canvasGroup>5__2; //Field offset: 0x28
		private WaitForSeconds <wait>5__3; //Field offset: 0x30

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
		public <Start>d__1(int <>1__state) { }

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
	private StorePackType _storePackType; //Field offset: 0x20

	public StoreButtonPackIndicatorBadge() { }

	private void Init() { }

	[IteratorStateMachine(typeof(<Start>d__1))]
	private IEnumerator Start() { }

}

