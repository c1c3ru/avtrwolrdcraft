namespace Game.Level;

public class LevelWeatherManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<ExtraDataListEntry, ExtraDataListEntry> <>9__68_0; //Field offset: 0x8
		public static Func<ExtraDataListEntry, Boolean> <>9__68_1; //Field offset: 0x10
		public static Comparison<AreaSettings> <>9__85_0; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal int <CheckOverlapsAndGaps>b__85_0(AreaSettings a, AreaSettings b) { }

		internal ExtraDataListEntry <LoadCurrentWeatherData>b__68_0(ExtraDataListEntry entry) { }

		internal bool <LoadCurrentWeatherData>b__68_1(ExtraDataListEntry e) { }

	}

	internal struct AreaSettings
	{
		public float leftXValue; //Field offset: 0x0
		public float rightXValue; //Field offset: 0x4
		[Range(0, 5.12)]
		[Tooltip("0 for top of the screen, 5.12 for the bottom of the screen")]
		public float weatherEffectHeight; //Field offset: 0x8

	}

	private enum CloudsClusterPosition
	{
		OffScreen = 0,
		ScreenEdges = 1,
		ScreenCenter = 2,
	}

	[CompilerGenerated]
	private static Action<WeatherType> OnWeatherIntensityChange; //Field offset: 0x0
	public const float DefaultParticleHeight = 5,12; //Field offset: 0x0
	public static float WeatherIntensity; //Field offset: 0x8
	[CompilerGenerated]
	private static LevelWeatherManager <Instance>k__BackingField; //Field offset: 0x10
	[Header("Particles")]
	[SerializeField]
	private ParticleSystem _rainGroundImpactParticleSystem; //Field offset: 0x20
	[SerializeField]
	private ParticleSystem _rainWaterImpactParticleSystem; //Field offset: 0x28
	[SerializeField]
	private ParticleSystem _rainForegroundParticleSystem; //Field offset: 0x30
	[SerializeField]
	private ParticleSystem _rainMidgroundParticleSystem; //Field offset: 0x38
	[SerializeField]
	private ParticleSystem _rainBackgroundParticleSystem; //Field offset: 0x40
	[SerializeField]
	private ParticleSystem _snowForegroundParticleSystem; //Field offset: 0x48
	[SerializeField]
	private ParticleSystem _snowMidgroundParticleSystem; //Field offset: 0x50
	[SerializeField]
	private ParticleSystem _snowBackgroundParticleSystem; //Field offset: 0x58
	[Header("Clouds & Overlay")]
	[SerializeField]
	private GameObject _cloudsLeftCluster; //Field offset: 0x60
	[SerializeField]
	private GameObject _cloudsRighttCluster; //Field offset: 0x68
	[SerializeField]
	private SpriteRenderer[] _overlays; //Field offset: 0x70
	[SerializeField]
	private BackgroundPlanet _backgroundPlanet; //Field offset: 0x78
	[Header("Rain Data")]
	[SerializeField]
	private LevelPuddleData _levelPuddleData; //Field offset: 0x80
	[SerializeField]
	private GameObject _vfxAreaBase; //Field offset: 0x88
	[SerializeField]
	private GameObject _vfxTemplateBase; //Field offset: 0x90
	[Header("Snow Data")]
	[SerializeField]
	private GameObject _snowMeshCreator; //Field offset: 0x98
	[SerializeField]
	private GameObject _snowMeshManual; //Field offset: 0xA0
	public bool ShouldDefaultFloorHideSnowOnItems; //Field offset: 0xA8
	[Header("World Data")]
	[SerializeField]
	private bool _forceSpecifecWeatherType; //Field offset: 0xA9
	[ConditionalField("_forceSpecifecWeatherType", True, True, (array) null)]
	[SerializeField]
	private WeatherType _forcedWeatherType; //Field offset: 0xAC
	private string overlayAll; //Field offset: 0xB0
	private string overlayBG; //Field offset: 0xB8
	private string _world; //Field offset: 0xC0
	private bool _hasMovedCloudClusters; //Field offset: 0xC8
	private bool _hasSetOverlay; //Field offset: 0xC9
	private float _minAreaWidth; //Field offset: 0xCC
	private float _maxAreaWidth; //Field offset: 0xD0
	[Header("Areas")]
	public bool NotAffectedByWeather; //Field offset: 0xD4
	public bool IsLevelVertical; //Field offset: 0xD5
	[ConditionalField("IsLevelVertical", True, True, (array) null)]
	[SerializeField]
	public float VerticalLevelHeight; //Field offset: 0xD8
	public List<AreaSettings> IndoorAreas; //Field offset: 0xE0
	public List<AreaSettings> OutdoorAreas; //Field offset: 0xE8
	public int OutdoorWeatherParticlesSortingOrder; //Field offset: 0xF0
	public float BackgroundWeatherParticlesHeight; //Field offset: 0xF4
	protected float _transitionDuration; //Field offset: 0xF8
	private bool _isTransitioning; //Field offset: 0xFC
	private List<LevelParticleSpawnInArea> currentParticleSpawnInAreas; //Field offset: 0x100
	private List<GameObject> currentVFXAreas; //Field offset: 0x108
	[Header("Editor")]
	public WeatherType TestedWeatherType; //Field offset: 0x110
	public bool ShouldTestWeatherEffectInScene; //Field offset: 0x114
	public bool DontAutoLoadWeatherData; //Field offset: 0x115
	private int _initAttempt; //Field offset: 0x118

	public static event Action<WeatherType> OnWeatherIntensityChange
	{
		[CompilerGenerated]
		 add { } //Length: 240
		[CompilerGenerated]
		 remove { } //Length: 240
	}

	public private static LevelWeatherManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 96
	}

	public bool IsTransitioning
	{
		 get { } //Length: 8
	}

	public SpriteRenderer[] Overlays
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	private static LevelWeatherManager() { }

	public LevelWeatherManager() { }

	[CompilerGenerated]
	private void <OnWeatherChange>b__64_0() { }

	[CompilerGenerated]
	private void <SetOverlayColor>b__75_0() { }

	[CompilerGenerated]
	public static void add_OnWeatherIntensityChange(Action<WeatherType> value) { }

	private void AddBackgroundParticles() { }

	private void AddForegroundParticles() { }

	private void AddSnowComponentToItem(LevelItem item) { }

	private void AddSnowComponentToItems(List<LevelItem> list) { }

	private void AddSnowEffectOnItem(GameObject gameObject) { }

	private void Awake() { }

	private List<Single> CalculateParticleSystemSizes(Vector2 area) { }

	public static bool CheckOverlapsAndGaps(List<AreaSettings> listA, List<AreaSettings> listB) { }

	private void CloudsClusterMovement(WeatherType weatherType) { }

	private Mesh CreateMesh(VFXAreaData vfxAreaData) { }

	private LevelWeatherData GatherCurrentWeatherData() { }

	[CompilerGenerated]
	public static LevelWeatherManager get_Instance() { }

	public bool get_IsTransitioning() { }

	public SpriteRenderer[] get_Overlays() { }

	public WeatherType GetCurrentWeatherType() { }

	private static string GetHierarchyPath(Transform transform) { }

	public static Vector2 GetXRange(List<AreaSettings> listA, List<AreaSettings> listB) { }

	private void Init() { }

	private void InitWeatherEffect() { }

	private bool IsOutdoor(float value) { }

	public bool IsOutdoor(Transform transform) { }

	private void LoadCurrentWeatherData() { }

	private void LoadCurrentWeatherState() { }

	private void MoveCloudsClusterToPosition(CloudsClusterPosition cloudsClusterPosition) { }

	private void OnDestroy() { }

	private void OnPostInitAction() { }

	private void OnPrefabRuntimeSpawn(PDPrefab instance, bool _) { }

	private void OnWeatherChange(WeatherType weatherType) { }

	[CompilerGenerated]
	public static void remove_OnWeatherIntensityChange(Action<WeatherType> value) { }

	private void RemoveAllExistingParticles() { }

	[CompilerGenerated]
	private static void set_Instance(LevelWeatherManager value) { }

	public void set_Overlays(SpriteRenderer[] value) { }

	private void SetOverlayColor(WeatherType weatherType) { }

	private void UpdateOverlayOverTime(SpriteRenderer overlay) { }

	public void WeatherIntensityChange(WeatherType weatherType, float newIntensity) { }

}

