namespace Game.Level;

public class LevelFlightScheduleBoard : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <ClickOnAllScreens>d__3 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelFlightScheduleBoard <>4__this; //Field offset: 0x20
		private LevelToggleableSprite[] <>7__wrap1; //Field offset: 0x28
		private int <>7__wrap2; //Field offset: 0x30

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
		public <ClickOnAllScreens>d__3(int <>1__state) { }

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
	protected LevelToggleableSprite[] _allScreens; //Field offset: 0x20
	private bool _isClicked; //Field offset: 0x28

	public LevelFlightScheduleBoard() { }

	[IteratorStateMachine(typeof(<ClickOnAllScreens>d__3))]
	private IEnumerator ClickOnAllScreens() { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

