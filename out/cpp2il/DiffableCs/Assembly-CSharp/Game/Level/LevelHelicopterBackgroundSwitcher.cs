namespace Game.Level;

public class LevelHelicopterBackgroundSwitcher : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass30_0
	{
		public LevelHelicopterBackgroundSwitcher <>4__this; //Field offset: 0x10
		public int index; //Field offset: 0x18
		public Action <>9__1; //Field offset: 0x20

		public <>c__DisplayClass30_0() { }

		internal void <FlyDown>b__0() { }

		internal void <FlyDown>b__1() { }

	}

	[SerializeField]
	private LevelHelicopter _helicopter; //Field offset: 0x20
	[SerializeField]
	private Transform _background; //Field offset: 0x28
	[SerializeField]
	private Vector2[] _targetOffsets; //Field offset: 0x30
	[SerializeField]
	private int _startingIndex; //Field offset: 0x38
	[SerializeField]
	private float _moveDistance; //Field offset: 0x3C
	[SerializeField]
	private float _moveOutDuration; //Field offset: 0x40
	[SerializeField]
	private float _delayBetween; //Field offset: 0x44
	[SerializeField]
	private float _flightBoostDuration; //Field offset: 0x48
	[SerializeField]
	private int _debugTestIndex; //Field offset: 0x4C
	[SerializeField]
	private GameObject _hazeHolders; //Field offset: 0x50
	private Vector2[] _targetPositions; //Field offset: 0x58
	private int _currentIndex; //Field offset: 0x60
	private bool _isTransitioning; //Field offset: 0x64
	private bool _isFlyingHigh; //Field offset: 0x65
	private int _pendingFlyDownIndex; //Field offset: 0x68
	private int _flyUpTweenId; //Field offset: 0x6C
	private int _delayTweenId; //Field offset: 0x70
	private int _flyDownTweenId; //Field offset: 0x74
	public UnityEvent OnBackgroundChangeBeginAction; //Field offset: 0x78
	public UnityEvent OnBackgroundHiddenAction; //Field offset: 0x80
	public UnityEvent OnBackgroundChangeEndAction; //Field offset: 0x88
	[CompilerGenerated]
	private Action<Single, Single> OnBackgroundMoveY; //Field offset: 0x90

	public event Action<Single, Single> OnBackgroundMoveY
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LevelHelicopterBackgroundSwitcher() { }

	[CompilerGenerated]
	private void <FlyUp>b__29_0() { }

	[CompilerGenerated]
	public void add_OnBackgroundMoveY(Action<Single, Single> value) { }

	private void Awake() { }

	private void CancelTweens() { }

	private void ContinueSetBackground() { }

	[ContextMenu("Debug/Switch To Test Index")]
	private void Editor_SwitchToTestIndex() { }

	public void FlyDown(int index) { }

	public void FlyUp() { }

	public float GetCurrentTargetPositionY() { }

	public float GetRevealDuration() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	[CompilerGenerated]
	public void remove_OnBackgroundMoveY(Action<Single, Single> value) { }

	public void SetBackground(int index) { }

	private void SetX(Transform target, float x) { }

	private void SyncHazeHoldersToHelicopter() { }

}

