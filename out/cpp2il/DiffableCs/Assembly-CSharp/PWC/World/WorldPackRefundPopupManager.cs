namespace PWC.World;

public class WorldPackRefundPopupManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__3_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <TryShowRefundPopup>b__3_0() { }

	}

	[CompilerGenerated]
	private sealed class <TryShowRefundPopup>d__3 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public WorldPackRefundPopupManager <>4__this; //Field offset: 0x20

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
		public <TryShowRefundPopup>d__3(int <>1__state) { }

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

	private static readonly Dictionary<String, GamePopupType> StorePackTypeToPopup; //Field offset: 0x0
	private static bool _didUserRefundSucceeded; //Field offset: 0x8

	private static WorldPackRefundPopupManager() { }

	public WorldPackRefundPopupManager() { }

	private void Start() { }

	[IteratorStateMachine(typeof(<TryShowRefundPopup>d__3))]
	private IEnumerator TryShowRefundPopup() { }

}

