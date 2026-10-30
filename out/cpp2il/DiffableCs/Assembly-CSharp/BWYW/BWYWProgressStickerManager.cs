namespace BWYW;

public class BWYWProgressStickerManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <Start>d__10 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BWYWProgressStickerManager <>4__this; //Field offset: 0x20

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
		public <Start>d__10(int <>1__state) { }

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
	private TMP_Text _skillLevelText; //Field offset: 0x20
	[SerializeField]
	private GameObject _skillLevelParent; //Field offset: 0x28
	[SerializeField]
	private TMP_Text _xpTargetText; //Field offset: 0x30
	[SerializeField]
	private TMP_Text _totalXpText; //Field offset: 0x38
	[SerializeField]
	private DeliveryProgressBar _progressBar; //Field offset: 0x40
	[SerializeField]
	private GameObject _indication; //Field offset: 0x48
	[SerializeField]
	private GameObject _xpTextParent; //Field offset: 0x50
	[SerializeField]
	private GameObject _finalTextParent; //Field offset: 0x58
	[SerializeField]
	private GameObject _finalLevelIcon; //Field offset: 0x60
	private SkillType _currentSkillType; //Field offset: 0x68

	public BWYWProgressStickerManager() { }

	public void OnClick() { }

	[IteratorStateMachine(typeof(<Start>d__10))]
	public IEnumerator Start() { }

}

