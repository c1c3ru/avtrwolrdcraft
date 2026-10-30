namespace Game.Home;

public class HomeClothesWidget : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <Start>d__4 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public HomeClothesWidget <>4__this; //Field offset: 0x20
		private int <tryCounter>5__2; //Field offset: 0x28

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
		public <Start>d__4(int <>1__state) { }

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
	private GameObject _view; //Field offset: 0x20
	[SerializeField]
	private Image _icon; //Field offset: 0x28
	private long _currentTime; //Field offset: 0x30
	private LevelType _levelType; //Field offset: 0x38

	public HomeClothesWidget() { }

	private void Init() { }

	public void OnButtonClick() { }

	[IteratorStateMachine(typeof(<Start>d__4))]
	private IEnumerator Start() { }

}

