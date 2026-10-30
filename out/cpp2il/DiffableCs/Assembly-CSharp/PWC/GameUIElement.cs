namespace PWC;

public class GameUIElement : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <ListenOnlyToUI>d__7 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public GameUIElement <>4__this; //Field offset: 0x20

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
		public <ListenOnlyToUI>d__7(int <>1__state) { }

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
	private static int <LastPointerDownFrameCount>k__BackingField; //Field offset: 0x0
	private bool _didDisableNonUIGameInteraction; //Field offset: 0x20

	public private static int LastPointerDownFrameCount
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 76
	}

	public GameUIElement() { }

	private void EnableNonUIGameInteraction(bool isEnabled) { }

	[CompilerGenerated]
	public static int get_LastPointerDownFrameCount() { }

	[IteratorStateMachine(typeof(<ListenOnlyToUI>d__7))]
	private IEnumerator ListenOnlyToUI() { }

	protected override void OnDisable() { }

	public override void OnPointerDown(PointerEventData eventData) { }

	[CompilerGenerated]
	private static void set_LastPointerDownFrameCount(int value) { }

}

