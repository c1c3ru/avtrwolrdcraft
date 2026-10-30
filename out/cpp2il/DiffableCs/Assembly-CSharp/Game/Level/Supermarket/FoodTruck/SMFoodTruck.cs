namespace Game.Level.Supermarket.FoodTruck;

public class SMFoodTruck : MonoBehaviour
{
	[SerializeField]
	private GameObject _electricGateButtonsParent; //Field offset: 0x20
	[SerializeField]
	private LevelElectricGate _electricGate; //Field offset: 0x28
	[SerializeField]
	private LevelDropArea[] _dropAreas; //Field offset: 0x30
	[SerializeField]
	private PDPrefabReference _boxPrefab; //Field offset: 0x38
	[SerializeField]
	private PDPrefabReference[] _itemsBank; //Field offset: 0x40

	public SMFoodTruck() { }

	[CompilerGenerated]
	private void <DriveAway>b__9_0() { }

	private void Awake() { }

	private void DriveAway() { }

	private void OnDestroy() { }

	private void OnItemPickUp(LevelItem levelItem) { }

	private void OnLevelPostInit() { }

}

