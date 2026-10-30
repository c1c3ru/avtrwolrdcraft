namespace Game.Level;

[AddComponentMenu(null)]
public class LevelTrain : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__22_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <OnCharacterSpawnPostInit>b__22_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public Action onCompleteAction; //Field offset: 0x10
		public LevelTrain <>4__this; //Field offset: 0x18
		public bool value; //Field offset: 0x20

		public <>c__DisplayClass18_0() { }

		internal void <Animate>b__0() { }

	}

	private const float DOORS_OPEN_X_POSITION = 2,5; //Field offset: 0x0
	private const float DOORS_CLOSED_X_POSITION = 0,8; //Field offset: 0x0
	[SerializeField]
	private GameObject _doorRLeft; //Field offset: 0x20
	[SerializeField]
	private GameObject _doorRRight; //Field offset: 0x28
	[SerializeField]
	private LevelSpawnMultipleInRandomLocations _spawnInRandomLocations; //Field offset: 0x30
	[SerializeField]
	private float _startXPosition; //Field offset: 0x38
	[SerializeField]
	private float _stopXPosition; //Field offset: 0x3C
	[SerializeField]
	private float _endXPosition; //Field offset: 0x40
	[SerializeField]
	private LevelTrainStopSign _stopSign; //Field offset: 0x48
	private bool _isDoorsClosed; //Field offset: 0x50
	private bool _isMoving; //Field offset: 0x51
	private bool _isAtStartingPoint; //Field offset: 0x52

	public bool IsAtStartingPoint
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public LevelTrain() { }

	[CompilerGenerated]
	private void <OnDriverCabClick>b__21_0() { }

	private void Animate(bool value, Action onCompleteAction) { }

	private void AnimateDoors() { }

	private void Awake() { }

	public bool get_IsAtStartingPoint() { }

	public void OnCharacterSpawnPostInit() { }

	private void OnDestroy() { }

	public void OnDoorsClick() { }

	public void OnDriverCabClick() { }

	private void OnLevelPrePostInit() { }

	public void set_IsAtStartingPoint(bool value) { }

}

