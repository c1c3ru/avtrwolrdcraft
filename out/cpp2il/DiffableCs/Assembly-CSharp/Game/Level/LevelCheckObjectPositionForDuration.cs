namespace Game.Level;

public class LevelCheckObjectPositionForDuration : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <CountdownRoutine>d__40 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCheckObjectPositionForDuration <>4__this; //Field offset: 0x20

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
		public <CountdownRoutine>d__40(int <>1__state) { }

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

	private const float MIN_DURATION = 0,01; //Field offset: 0x0
	[SerializeField]
	[Tooltip("Leave empty to check this GameObject's own transform.")]
	private Transform _target; //Field offset: 0x20
	[SerializeField]
	private bool _checkXAxis; //Field offset: 0x28
	[ConditionalField("_checkXAxis", True, True, (array) null)]
	[SerializeField]
	private float _minX; //Field offset: 0x2C
	[ConditionalField("_checkXAxis", True, True, (array) null)]
	[SerializeField]
	private float _maxX; //Field offset: 0x30
	[SerializeField]
	private bool _checkYAxis; //Field offset: 0x34
	[ConditionalField("_checkYAxis", True, True, (array) null)]
	[SerializeField]
	private float _minY; //Field offset: 0x38
	[ConditionalField("_checkYAxis", True, True, (array) null)]
	[SerializeField]
	private float _maxY; //Field offset: 0x3C
	[Min(0.01)]
	[SerializeField]
	[Tooltip("Uninterrupted seconds the target must stay inside the range.")]
	private float _duration; //Field offset: 0x40
	[SerializeField]
	[Tooltip("Any camera movement restarts the countdown, so the event needs the camera to stand still for the whole duration.")]
	private bool _requireStillCamera; //Field offset: 0x44
	[SerializeField]
	[Tooltip("Re-check the range while a dragged item moves. Turn on when the target is a LevelItem.")]
	private bool _followItemDrag; //Field offset: 0x45
	[ConditionalField("_followItemDrag", True, True, (array) null)]
	[SerializeField]
	[Tooltip("The dragged item to follow. Leave empty to use a LevelItem on the target object.")]
	private LevelItem _itemToFollow; //Field offset: 0x48
	[SerializeField]
	[Tooltip("Run one check once the level finished its post init, so a target already parked inside the range starts counting.")]
	private bool _checkOnLevelPostInit; //Field offset: 0x50
	[SerializeField]
	[Tooltip("Gate the whole check behind a prerequisite. Nothing is checked until SetPrerequisiteMet(true) is called from another UnityEvent (day/night, another secret, a switch...).")]
	private bool _requirePrerequisite; //Field offset: 0x51
	[SerializeField]
	private UnityEvent _onInRangeForDurationEvent; //Field offset: 0x58
	[SerializeField]
	[Tooltip("Fired when the target leaves a range it was inside, whether or not the duration was completed. A camera move only restarts the countdown - it does not fire this.")]
	private UnityEvent _onExitRangeEvent; //Field offset: 0x60
	private GameCamera _gameCamera; //Field offset: 0x68
	private Coroutine _countdownRoutine; //Field offset: 0x70
	private float _countdownEndTime; //Field offset: 0x78
	private bool _isInRange; //Field offset: 0x7C
	private bool _isPrerequisiteMet; //Field offset: 0x7D
	private bool _isSubscribedToCamera; //Field offset: 0x7E
	private bool _isSubscribedToItem; //Field offset: 0x7F
	private bool _hasLoggedMissingCamera; //Field offset: 0x80

	public bool IsCountingDown
	{
		 get { } //Length: 16
	}

	public bool IsPrerequisiteMet
	{
		 get { } //Length: 32
	}

	private Transform Target
	{
		private get { } //Length: 128
	}

	public LevelCheckObjectPositionForDuration() { }

	private void Awake() { }

	public void CheckNow() { }

	[IteratorStateMachine(typeof(<CountdownRoutine>d__40))]
	private IEnumerator CountdownRoutine() { }

	public bool get_IsCountingDown() { }

	public bool get_IsPrerequisiteMet() { }

	private Transform get_Target() { }

	public bool IsTargetInRange() { }

	private void OnCameraChangePosition(Vector2 cameraPosition) { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnItemEndDrag(LevelItem item) { }

	private void OnItemEndLand(LevelDropArea dropArea) { }

	private void OnItemSyncPosition(DragDropItemBase item, Vector2 pointerPosition) { }

	private void OnLevelPostInit() { }

	public void Rearm() { }

	public void SetPrerequisiteMet(bool value) { }

	private void Start() { }

	public void StopCountdown() { }

	private void SubscribeToItem() { }

	private bool TrySubscribeToCamera() { }

	private void UnsubscribeFromCamera() { }

	private void UnsubscribeFromItem() { }

}

