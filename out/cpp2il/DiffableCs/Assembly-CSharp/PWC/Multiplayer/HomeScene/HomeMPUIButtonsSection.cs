namespace PWC.Multiplayer.HomeScene;

public class HomeMPUIButtonsSection : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<Boolean> <>9__18_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <OnStartAsHostButtonClick>b__18_0(bool isSuccess) { }

	}

	[CompilerGenerated]
	private sealed class <Start>d__9 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public HomeMPUIButtonsSection <>4__this; //Field offset: 0x20

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
		public <Start>d__9(int <>1__state) { }

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
	private GameObject _connectOptionsPanel; //Field offset: 0x20
	[SerializeField]
	private GameObject _leaveGamePanel; //Field offset: 0x28
	[SerializeField]
	private GameObject _mainButton; //Field offset: 0x30
	[SerializeField]
	private HomeMPUIJoinGameWindow _joinGameWindow; //Field offset: 0x38
	[SerializeField]
	private Image _mainButtonImage; //Field offset: 0x40
	[SerializeField]
	private Sprite _mainButtonEnterSprite; //Field offset: 0x48
	[SerializeField]
	private Sprite _mainButtonExitSprite; //Field offset: 0x50

	public HomeMPUIButtonsSection() { }

	private void Awake() { }

	private bool IsGameLatestBuild() { }

	private void OnDestroy() { }

	private void OnEnterMultiplayer() { }

	private void OnExitMultiplayer() { }

	public void OnLeaveGameNoButtonClick() { }

	public void OnLeaveGameYesButtonClick() { }

	public void OnMainButtonClick() { }

	public void OnStartAsClientButtonClick() { }

	public void OnStartAsHostButtonClick() { }

	private void ShowGameUpdatePopup() { }

	[IteratorStateMachine(typeof(<Start>d__9))]
	private IEnumerator Start() { }

	private void SyncMainButtonText() { }

}

