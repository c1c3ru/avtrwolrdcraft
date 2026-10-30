namespace PWC.Street;

public class StreetManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<StreetHouse> <>9__34_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <DeleteButtonPress>b__34_0(StreetHouse house) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass34_0
	{
		public StreetHouse centerdHouse; //Field offset: 0x10
		public StreetManager <>4__this; //Field offset: 0x18

		public <>c__DisplayClass34_0() { }

		internal void <DeleteButtonPress>b__1() { }

	}

	private enum SectionType
	{
		None = 0,
		R = 1,
		L = 2,
	}

	[CompilerGenerated]
	private static StreetManager <Instance>k__BackingField; //Field offset: 0x0
	[SerializeField]
	private StreetSelectionManager _selectionManager; //Field offset: 0x20
	[SerializeField]
	private BackgroundPlanet _planet; //Field offset: 0x28
	[SerializeField]
	private CameraIris _iris; //Field offset: 0x30
	[SerializeField]
	private StreetCamera _camera; //Field offset: 0x38
	[SerializeField]
	private RectTransform _scrollableArea; //Field offset: 0x40
	[SerializeField]
	private SpriteRenderer _backgroundSky; //Field offset: 0x48
	[SerializeField]
	private GameObject _sectionLPrefab; //Field offset: 0x50
	[SerializeField]
	private GameObject _sectionRPrefab; //Field offset: 0x58
	[SerializeField]
	private WorldCloudsSpawner _cloudsSpawner; //Field offset: 0x60
	[SerializeField]
	private Transform _cloudsEndPoint; //Field offset: 0x68
	[SerializeField]
	private GameObject _cloudSectionLPrefab; //Field offset: 0x70
	[SerializeField]
	private GameObject _cloudSectionRPrefab; //Field offset: 0x78
	[SerializeField]
	private Transform _vehiclesEndPointL; //Field offset: 0x80
	[SerializeField]
	private Transform _vehiclesEndPointR; //Field offset: 0x88
	[SerializeField]
	private StreetVehiclesSpawner _vehiclesSpawnerL; //Field offset: 0x90
	[SerializeField]
	private StreetVehiclesSpawner _vehiclesSpawnerR; //Field offset: 0x98
	private SectionType _currentSectionType; //Field offset: 0xA0
	private readonly List<StreetHouse> _houses; //Field offset: 0xA8
	private readonly List<Transform> _sections; //Field offset: 0xB0
	private readonly List<StreetCloudSection> _cloudSections; //Field offset: 0xB8

	public private static StreetManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public StreetSelectionManager SelectionManager
	{
		 get { } //Length: 8
	}

	public StreetManager() { }

	[CompilerGenerated]
	private void <InitStreet>b__29_0() { }

	[CompilerGenerated]
	private void <InitStreet>b__29_1(StreetCloudSection cloudSection) { }

	private void Awake() { }

	public void DeleteButtonPress() { }

	[CompilerGenerated]
	public static StreetManager get_Instance() { }

	public StreetSelectionManager get_SelectionManager() { }

	public StreetHouse GetNearestTransformToXPosition(float xPosition) { }

	private void InitStreet() { }

	private StreetHouse InstantiateHouse(WorldMakerBuildingType buildingType, string id, float xPosition, bool isNew) { }

	private void InstantiateSection(float xPosition) { }

	private void OnDestroy() { }

	public void OnHouseLayoutClick(WorldMakerBuildingType buildingType) { }

	[CompilerGenerated]
	private static void set_Instance(StreetManager value) { }

	private void Start() { }

}

