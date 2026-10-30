namespace Game.Level;

public class LevelButlerCaller : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <SwitchSprite>d__7 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelButlerCaller <>4__this; //Field offset: 0x20

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
		public <SwitchSprite>d__7(int <>1__state) { }

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
	private SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x28
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x30
	[SerializeField]
	private LevelCharacterCaller _characterCaller; //Field offset: 0x38
	[SerializeField]
	private string _soundName; //Field offset: 0x40
	private bool _isInteractable; //Field offset: 0x48

	public LevelButlerCaller() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[IteratorStateMachine(typeof(<SwitchSprite>d__7))]
	private IEnumerator SwitchSprite() { }

}

