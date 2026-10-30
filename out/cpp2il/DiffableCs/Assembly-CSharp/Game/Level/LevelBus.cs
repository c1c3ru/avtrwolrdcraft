namespace Game.Level;

public class LevelBus : LevelDrivingVehicleBase
{
	internal enum BusType
	{
		None = 0,
		School = 1,
		City = 2,
	}

	private static Dictionary<BusType, LevelBus> _allBuses; //Field offset: 0x0
	[SerializeField]
	private LevelDoor _busDoor; //Field offset: 0x90
	[SerializeField]
	private BusType _busType; //Field offset: 0x98
	private bool _needToFocus; //Field offset: 0x9C
	private bool _isAtStartingPoint; //Field offset: 0x9D
	public Action OnEndOfDriveAction; //Field offset: 0xA0

	private static LevelBus() { }

	public LevelBus() { }

	protected virtual void Awake() { }

	public void CallBusToStation() { }

	protected virtual void Drive() { }

	public static LevelBus GetBusById(BusType busId) { }

	public bool IsBusAtStartingPoint() { }

	protected virtual void OnDestroy() { }

	private void OnLevelPostInit() { }

	protected void OnPreInit() { }

	protected virtual void OnPrePostInit() { }

	protected virtual void OnVehicleStop(VehicleStopType vehicleStopType) { }

	protected virtual void SnapToStation(int stationIndex) { }

	protected virtual bool StoppingCondition() { }

}

