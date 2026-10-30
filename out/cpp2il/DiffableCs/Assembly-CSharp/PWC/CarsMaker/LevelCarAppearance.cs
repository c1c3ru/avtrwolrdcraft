namespace PWC.CarsMaker;

public class LevelCarAppearance : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject, IVehiclePersistenceKey
{
	private const string PD_KEY_CAR_ID = "LevelCarAppearance_carId"; //Field offset: 0x0
	private const int NO_CAR_ID = -1; //Field offset: 0x0
	[SerializeField]
	private CarView _carView; //Field offset: 0x20
	private int _carId; //Field offset: 0x28

	public int CarId
	{
		 get { } //Length: 8
	}

	public LevelCarAppearance() { }

	public void Apply(int carId) { }

	private void Awake() { }

	public int get_CarId() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void Rebuild() { }

	private void SetCarId(int carId) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void StampSceneGuid() { }

	public override bool TryGetPersistenceKey(out string persistenceKey) { }

	private static bool TryOverrideGuidCreation(PDSceneObject sceneObject, out string sceneGuid) { }

}

