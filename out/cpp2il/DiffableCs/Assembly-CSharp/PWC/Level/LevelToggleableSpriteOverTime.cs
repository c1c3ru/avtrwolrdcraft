namespace PWC.Level;

public class LevelToggleableSpriteOverTime : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <StartToggling>d__18 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelToggleableSpriteOverTime <>4__this; //Field offset: 0x20

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
		public <StartToggling>d__18(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <ToggleSprites>d__23 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelToggleableSpriteOverTime <>4__this; //Field offset: 0x20
		private int <index>5__2; //Field offset: 0x28

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
		public <ToggleSprites>d__23(int <>1__state) { }

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
	protected SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x28
	[SerializeField]
	protected string _loopSoundName; //Field offset: 0x30
	[SerializeField]
	protected string _onSoundName; //Field offset: 0x38
	[SerializeField]
	protected string _offSoundName; //Field offset: 0x40
	[SerializeField]
	protected float _timeBetweenSprites; //Field offset: 0x48
	[SerializeField]
	private Sprite[] _sprites; //Field offset: 0x50
	private bool _isToggling; //Field offset: 0x58
	private bool _startTogglingOnEnable; //Field offset: 0x59
	private WaitForSeconds _timeBetweenToggling; //Field offset: 0x60
	[CompilerGenerated]
	private Action<Boolean> OnToggleSetActiveAction; //Field offset: 0x68

	public event Action<Boolean> OnToggleSetActiveAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LevelToggleableSpriteOverTime() { }

	[CompilerGenerated]
	public void add_OnToggleSetActiveAction(Action<Boolean> value) { }

	private void Awake() { }

	public void ForceClick() { }

	public void ForceStartToggle() { }

	public void ForceStopToggle() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnEnable() { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public void remove_OnToggleSetActiveAction(Action<Boolean> value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SetSprite(Sprite sprite) { }

	private void SoundLoopSetActive(bool value) { }

	[IteratorStateMachine(typeof(<StartToggling>d__18))]
	private IEnumerator StartToggling() { }

	private void StopToggling() { }

	[IteratorStateMachine(typeof(<ToggleSprites>d__23))]
	private IEnumerator ToggleSprites() { }

}

