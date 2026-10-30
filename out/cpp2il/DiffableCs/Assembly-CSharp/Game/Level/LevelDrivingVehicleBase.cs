namespace Game.Level;

public class LevelDrivingVehicleBase : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass28_0
	{
		public LevelDrivingVehicleBase <>4__this; //Field offset: 0x10
		public VehicleStop curStop; //Field offset: 0x18

		public <>c__DisplayClass28_0() { }

		internal void <LeaveStation>b__0() { }

		internal void <LeaveStation>b__1() { }

	}

	[SerializeField]
	private float _startingXPosition; //Field offset: 0x20
	[SerializeField]
	private float _endingXPosition; //Field offset: 0x24
	[SerializeField]
	private float _drivingYPosition; //Field offset: 0x28
	[SerializeField]
	private bool _isDestroyedOnDestination; //Field offset: 0x2C
	[SerializeField]
	private float _drivingSpeed; //Field offset: 0x30
	[SerializeField]
	private bool _requiresADriverToDrive; //Field offset: 0x34
	[ConditionalField("_requiresADriverToDrive", True, True, (array) null)]
	[SerializeField]
	private LevelSitArea _driverDropArea; //Field offset: 0x38
	[SerializeField]
	protected GameObject _clickBlockerObject; //Field offset: 0x40
	[SerializeField]
	protected List<VehicleStop> _vehicleStops; //Field offset: 0x48
	[SerializeField]
	private string _vehicleStopSoundName; //Field offset: 0x50
	[SerializeField]
	private string _vehicleStartSoundName; //Field offset: 0x58
	[SerializeField]
	protected bool _isDrivingOnAwake; //Field offset: 0x60
	protected int _curStation; //Field offset: 0x64
	private bool _isNextStopAStation; //Field offset: 0x68
	private LevelCharacter _currentDriver; //Field offset: 0x70
	private int _drivingTweenId; //Field offset: 0x78
	private int _leaveStationTweenId; //Field offset: 0x7C
	private int _enterStationTweenId; //Field offset: 0x80
	public UnityEvent OnLeaveStationAction; //Field offset: 0x88

	public LevelDrivingVehicleBase() { }

	[CompilerGenerated]
	private void <CheckForStop>b__27_0() { }

	[CompilerGenerated]
	private void <Drive>b__25_0() { }

	[CompilerGenerated]
	private void <Drive>b__25_1() { }

	[CompilerGenerated]
	private void <Drive>b__25_2() { }

	protected override void Awake() { }

	private void CheckForStop() { }

	protected override void Drive() { }

	private float GetNextStationXPosition() { }

	public void LeaveStation() { }

	private void OnAvatarEndDrop(LevelAvatarRestAreaBase _, ILevelAvatar avatar) { }

	private void OnAvatarPickUp(LevelAvatarRestAreaBase _, ILevelAvatar avatar) { }

	public override void OnBlockerClick() { }

	protected override void OnDestroy() { }

	protected override void OnPrePostInit() { }

	protected override void OnVehicleStop(VehicleStopType vehicleStopType) { }

	protected override void SnapToStation(int stationIndex) { }

	protected override bool StoppingCondition() { }

}

