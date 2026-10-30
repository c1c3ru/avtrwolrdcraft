namespace Game.Level;

public class LevelIceCreamTruck : LevelDrivingVehicleBase, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x90
	[SerializeField]
	private int _minNumberOfCustomersToStop; //Field offset: 0x98
	[SerializeField]
	private GameObject _doorClickBlocker; //Field offset: 0xA0
	[SerializeField]
	private LevelFoodTruckDoor _foodTruckDoor; //Field offset: 0xA8
	[SerializeField]
	private LevelDropArea _cashierArea; //Field offset: 0xB0
	[SerializeField]
	private UnityEvent _onVehicleStopAction; //Field offset: 0xB8
	private int _currentParkingStation; //Field offset: 0xC0
	private VehicleStopType _currentStopType; //Field offset: 0xC4

	public LevelIceCreamTruck() { }

	protected virtual void Drive() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public virtual void OnBlockerClick() { }

	protected virtual void OnPrePostInit() { }

	protected virtual void OnVehicleStop(VehicleStopType vehicleStopType) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	protected virtual bool StoppingCondition() { }

	private void ToggleDoorInteractability(bool state) { }

}

