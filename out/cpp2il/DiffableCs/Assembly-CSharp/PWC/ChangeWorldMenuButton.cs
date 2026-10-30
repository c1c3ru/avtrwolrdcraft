namespace PWC;

public class ChangeWorldMenuButton : GameUIElement
{
	[CompilerGenerated]
	private sealed class <ScrollToStart>d__18 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ChangeWorldMenuButton <>4__this; //Field offset: 0x20

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
		public <ScrollToStart>d__18(int <>1__state) { }

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
	private GameObject _menuHolder; //Field offset: 0x28
	[SerializeField]
	private GameObject _background; //Field offset: 0x30
	[SerializeField]
	private GameObject _navigationHolder; //Field offset: 0x38
	[SerializeField]
	private Transform _buttonsContainer; //Field offset: 0x40
	[SerializeField]
	private ScrollRect _scrollRect; //Field offset: 0x48
	[SerializeField]
	private float _xOpenedValue; //Field offset: 0x50
	[SerializeField]
	private float _xClosedValue; //Field offset: 0x54
	[SerializeField]
	private float _backgroundXOpenedValue; //Field offset: 0x58
	[SerializeField]
	private float _backgroundXClosedValue; //Field offset: 0x5C
	[SerializeField]
	private GameObject[] _hideableButtons; //Field offset: 0x60
	[SerializeField]
	private float _hideableButtonSpacing; //Field offset: 0x68
	public bool _isOpen; //Field offset: 0x6C
	private float _hiddenButtonsOffset; //Field offset: 0x70

	public ChangeWorldMenuButton() { }

	public void CloseIfOpen() { }

	private float GetHiddenButtonsOffset() { }

	public void OnButtonClick() { }

	private void ReorderButtons() { }

	[IteratorStateMachine(typeof(<ScrollToStart>d__18))]
	private IEnumerator ScrollToStart() { }

	private void SetIsOpen(bool isOpen, bool useTween, bool force = false) { }

	private void Start() { }

}

