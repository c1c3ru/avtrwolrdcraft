namespace Game.Level;

public class LevelHologramProjectorHandler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public LevelCharacter character; //Field offset: 0x10

		public <>c__DisplayClass12_0() { }

		internal void <StartCounting>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <StartCounting>d__12 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelHologramProjectorHandler <>4__this; //Field offset: 0x20
		private int <i>5__2; //Field offset: 0x28

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
		public <StartCounting>d__12(int <>1__state) { }

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

	private const string CELEBRATING_ANIMATION_NAME = "CA/Celebrating/Celebrating_"; //Field offset: 0x0
	[SerializeField]
	private SpriteRenderer _countdownSpriteRenderer; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer _projectorSpriteRenderer; //Field offset: 0x28
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x30
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x38
	[SerializeField]
	private Sprite[] _countdownSprites; //Field offset: 0x40
	[SerializeField]
	private string _countSoundName; //Field offset: 0x48
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x50
	private bool _isCounting; //Field offset: 0x58
	private Coroutine _countdownCoroutine; //Field offset: 0x60
	private int _TweenID; //Field offset: 0x68

	public LevelHologramProjectorHandler() { }

	private void OnDisable() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void ResetCountdown() { }

	private void SetSpriteAlpha(float value) { }

	[IteratorStateMachine(typeof(<StartCounting>d__12))]
	private IEnumerator StartCounting() { }

	private void StopCountdown() { }

}

