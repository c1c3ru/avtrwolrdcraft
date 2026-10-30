namespace Game.Level;

public class LevelDeliveryTruck : LevelDrivingVehicleBase
{
	[SerializeField]
	private Transform _deliveryPoint; //Field offset: 0x90
	[SerializeField]
	private LevelDropArea _deliveryDropArea; //Field offset: 0x98
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0xA0
	[SerializeField]
	protected PDPrefabReference _boxPrefabReference; //Field offset: 0xA8
	[SerializeField]
	private LevelDriverSitAreaHandler _driverSitAreaHandler; //Field offset: 0xB0
	private List<PDPrefab> allPDPrefabs; //Field offset: 0xB8

	public LevelDeliveryTruck() { }

	[CompilerGenerated]
	private void <StoppingCondition>b__7_0() { }

	[CompilerGenerated]
	private void <StoppingCondition>b__7_1() { }

	protected override string GetBulkDataKey() { }

	private LevelSpawn GetPrefabToSpawn() { }

	private string GlobalSpawnerGUID() { }

	protected virtual void OnPrePostInit() { }

	protected virtual bool StoppingCondition() { }

}

