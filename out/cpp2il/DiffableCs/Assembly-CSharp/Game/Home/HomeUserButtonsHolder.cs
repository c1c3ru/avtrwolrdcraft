namespace Game.Home;

public class HomeUserButtonsHolder : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <Start>d__12 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public HomeUserButtonsHolder <>4__this; //Field offset: 0x20

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
		public <Start>d__12(int <>1__state) { }

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
	private GameObject _signedUserButton; //Field offset: 0x20
	[SerializeField]
	private GameObject _notSignedUserButton; //Field offset: 0x28
	[SerializeField]
	private GameObject _comingSoonButton; //Field offset: 0x30
	[SerializeField]
	private GameObject _comingSoonTooltip; //Field offset: 0x38
	[SerializeField]
	private GameObject _muiltiplayerClickBlocker; //Field offset: 0x40
	[SerializeField]
	private GameObject _multiplayerTooltip; //Field offset: 0x48
	private StoreTweenToolipHandle _comingSoontweenTooltipHandle; //Field offset: 0x50
	private StoreTweenToolipHandle _multiplayerClickBLockerTweenTooltipHandle1; //Field offset: 0x58

	public HomeUserButtonsHolder() { }

	private void Awake() { }

	public void OnComingSoonButtonClick() { }

	private void OnDestroy() { }

	private void OnEnterMultiplayer() { }

	private void OnExitMultiplayer() { }

	public void OnMultiplayerClickBlockerButtonClick() { }

	[IteratorStateMachine(typeof(<Start>d__12))]
	private IEnumerator Start() { }

}

