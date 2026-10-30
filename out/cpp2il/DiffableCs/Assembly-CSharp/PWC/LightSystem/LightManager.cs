namespace PWC.LightSystem;

public class LightManager : MonoBehaviour
{
	public const float LOWEST_LIGHT_INTENSITY = 0,6; //Field offset: 0x0
	[CompilerGenerated]
	private static Action OnPostInitAction; //Field offset: 0x0
	[CompilerGenerated]
	private static LightManager <Instance>k__BackingField; //Field offset: 0x8
	[Range(0, 1)]
	[SerializeField]
	protected float _skyLightIntensity; //Field offset: 0x20
	[CompilerGenerated]
	private bool <DidInit>k__BackingField; //Field offset: 0x24
	private float _currentSkyLightIntensity; //Field offset: 0x28

	public static event Action OnPostInitAction
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public float CurrentSkyLightIntensity
	{
		 get { } //Length: 8
	}

	public private bool DidInit
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private static LightManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public float SkyLightIntensity
	{
		 get { } //Length: 8
	}

	public LightManager() { }

	[CompilerGenerated]
	public static void add_OnPostInitAction(Action value) { }

	private void Awake() { }

	public float get_CurrentSkyLightIntensity() { }

	[CompilerGenerated]
	public bool get_DidInit() { }

	[CompilerGenerated]
	public static LightManager get_Instance() { }

	public float get_SkyLightIntensity() { }

	public void Init() { }

	private void LateUpdate() { }

	private void OnDestroy() { }

	[CompilerGenerated]
	public static void remove_OnPostInitAction(Action value) { }

	[CompilerGenerated]
	private void set_DidInit(bool value) { }

	[CompilerGenerated]
	private static void set_Instance(LightManager value) { }

	public void SetCurrentSkyLightIntensity(float intensity) { }

	public void UpdateAllLights() { }

}

