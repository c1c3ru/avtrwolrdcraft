namespace Game.Store;

public class StoreNewUserGiftCurrencyButton : ButtonBase
{
	[CompilerGenerated]
	private sealed class <Start>d__5 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public StoreNewUserGiftCurrencyButton <>4__this; //Field offset: 0x20

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
		public <Start>d__5(int <>1__state) { }

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
	private UnityEvent _giftEnableEvents; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _giftDisableEvents; //Field offset: 0x30
	private int _itemIndex; //Field offset: 0x38

	public StoreNewUserGiftCurrencyButton() { }

	protected virtual void Awake() { }

	protected virtual void OnClick() { }

	[IteratorStateMachine(typeof(<Start>d__5))]
	private IEnumerator Start() { }

}

