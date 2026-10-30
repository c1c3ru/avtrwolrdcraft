namespace Game.Level;

public class LevelCharacterSummoningBellItemHandler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <CallCharacterCoroutine>d__5 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCharacterSummoningBellItemHandler <>4__this; //Field offset: 0x20

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
		public <CallCharacterCoroutine>d__5(int <>1__state) { }

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
	private LevelCharacterCaller _characterCaller; //Field offset: 0x20
	[SerializeField]
	private string _soundName; //Field offset: 0x28
	private bool _isInteractable; //Field offset: 0x30

	public LevelCharacterSummoningBellItemHandler() { }

	public void CallCharacter() { }

	[IteratorStateMachine(typeof(<CallCharacterCoroutine>d__5))]
	private IEnumerator CallCharacterCoroutine() { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

