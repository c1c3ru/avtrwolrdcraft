namespace Game.Level;

public class LevelButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerUpHandler, IPointerDownHandler, ILevelMakerDisabledWhileInEditMode
{
	[CompilerGenerated]
	private sealed class <OnPointerPress>d__30 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelButton <>4__this; //Field offset: 0x20

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
		public <OnPointerPress>d__30(int <>1__state) { }

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
	private Sprite _disabledSprite; //Field offset: 0x38
	[SerializeField]
	private string _soundName; //Field offset: 0x40
	[SerializeField]
	private bool _shouldBeLocked; //Field offset: 0x48
	[ConditionalField("_shouldBeLocked", True, True, (array) null)]
	[SerializeField]
	private bool _isShakeOnClickTry; //Field offset: 0x49
	[SerializeField]
	private UnityEvent _onClickEvent; //Field offset: 0x50
	[SerializeField]
	private UnityEvent _onPressEvent; //Field offset: 0x58
	[SerializeField]
	private UnityEvent _onPointerDownEvent; //Field offset: 0x60
	[SerializeField]
	private UnityEvent _onPointerUpEvent; //Field offset: 0x68
	[SerializeField]
	private UnityEvent _onTurnOffEvent; //Field offset: 0x70
	[SerializeField]
	private UnityEvent _onTurnOnEvent; //Field offset: 0x78
	[SerializeField]
	private bool _isPressedForDuration; //Field offset: 0x80
	[SerializeField]
	private float _pressDuration; //Field offset: 0x84
	[SerializeField]
	private bool _ignorePostInit; //Field offset: 0x88
	private bool _isUnlockedInternal; //Field offset: 0x89
	protected bool _isPressed; //Field offset: 0x8A
	private bool _isEnabled; //Field offset: 0x8B
	private bool _isShaking; //Field offset: 0x8C
	private int _tweenId; //Field offset: 0x90
	private Coroutine _pressCoroutine; //Field offset: 0x98

	public SpriteRenderer SpriteRenderer
	{
		 get { } //Length: 8
	}

	public LevelButton() { }

	[CompilerGenerated]
	private void <OnClick>b__31_0() { }

	[CompilerGenerated]
	private void <Shake>b__32_0() { }

	public override void Awake() { }

	public SpriteRenderer get_SpriteRenderer() { }

	private bool IsUnlocked() { }

	public void OnClick() { }

	private void OnDestroy() { }

	protected override void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	[IteratorStateMachine(typeof(<OnPointerPress>d__30))]
	private IEnumerator OnPointerPress() { }

	public override void OnPointerUp(PointerEventData eventData) { }

	public void SetOff() { }

	public void SetOn() { }

	public void SetPressedState(bool isPressed) { }

	public void SetUnlockedState(bool isUnlocked) { }

	private void Shake() { }

	public void ToggleOnOff() { }

	protected void UpdateButtonDisplay() { }

}

