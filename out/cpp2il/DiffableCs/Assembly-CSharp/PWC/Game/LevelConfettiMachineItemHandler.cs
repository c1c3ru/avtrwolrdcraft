namespace PWC.Game;

public class LevelConfettiMachineItemHandler : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler
{
	[CompilerGenerated]
	private sealed class <ParticlesCoroutine>d__9 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelConfettiMachineItemHandler <>4__this; //Field offset: 0x20

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
		public <ParticlesCoroutine>d__9(int <>1__state) { }

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
	private float _waitTime; //Field offset: 0x38
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x40
	[SerializeField]
	private string _onSoundName; //Field offset: 0x48
	[SerializeField]
	private string _offSoundName; //Field offset: 0x50
	private bool _isOn; //Field offset: 0x58

	public LevelConfettiMachineItemHandler() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	[IteratorStateMachine(typeof(<ParticlesCoroutine>d__9))]
	private IEnumerator ParticlesCoroutine() { }

}

