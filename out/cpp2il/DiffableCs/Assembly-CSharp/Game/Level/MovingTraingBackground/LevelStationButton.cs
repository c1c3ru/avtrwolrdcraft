namespace Game.Level.MovingTraingBackground;

public class LevelStationButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <BlinkLight>d__20 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelStationButton <>4__this; //Field offset: 0x20
		private LevelStationButtonState <buttonsState>5__2; //Field offset: 0x28

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
		public <BlinkLight>d__20(int <>1__state) { }

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

	public static Action<Int32> OnButtonClickAction; //Field offset: 0x0
	[SerializeField]
	private int _stationIndex; //Field offset: 0x20
	[SerializeField]
	private SerializableDictionaryBase<SelectionState, LevelStationButtonState> _buttonsStates; //Field offset: 0x28
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x30
	[SerializeField]
	private string _soundName; //Field offset: 0x38
	[SerializeField]
	private WorldBuildingType _moveToBuildingType; //Field offset: 0x40
	[SerializeField]
	private LevelType _moveToLevelType; //Field offset: 0x44
	private int _currentButtonIndex; //Field offset: 0x48
	private bool _isTrainMoving; //Field offset: 0x4C
	private LightSource _light; //Field offset: 0x50
	private bool _blinkOnStart; //Field offset: 0x58

	public WorldBuildingType MoveToBuildingType
	{
		 get { } //Length: 8
	}

	public LevelType MoveToLevelType
	{
		 get { } //Length: 8
	}

	public LevelStationButton() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<BlinkLight>d__20))]
	private IEnumerator BlinkLight() { }

	public WorldBuildingType get_MoveToBuildingType() { }

	public LevelType get_MoveToLevelType() { }

	private bool IsSelected() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public void OnTransitionEnd() { }

	public void SetMovingState(bool value) { }

	private void SetState(SelectionState selectionState) { }

	public void SyncState() { }

	private void UpdateCurrentStationIndex(int index) { }

}

