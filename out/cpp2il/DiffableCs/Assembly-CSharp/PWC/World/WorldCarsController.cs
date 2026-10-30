namespace PWC.World;

public class WorldCarsController : MonoBehaviour
{
	[SerializeField]
	private WorldCar _carPrefab; //Field offset: 0x20
	[SerializeField]
	private WorldRoadPoint[] _roadPoints; //Field offset: 0x28
	[SerializeField]
	private int _sortingOrder; //Field offset: 0x30
	[SerializeField]
	private int NumberOfCars; //Field offset: 0x34
	[SerializeField]
	private Transform _roadPointsParent; //Field offset: 0x38
	[SerializeField]
	private List<Int32> _carsIndexes; //Field offset: 0x40
	[SerializeField]
	private float _speed; //Field offset: 0x48
	[SerializeField]
	private List<Int32> _spawnPositionsIndexes; //Field offset: 0x50

	public WorldCarsController() { }

	public void Init() { }

	private void InitCars() { }

}

