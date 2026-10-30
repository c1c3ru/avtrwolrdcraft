namespace PWC.LightSystem;

public class LightArea : MonoBehaviour
{
	public static readonly List<LightArea> List; //Field offset: 0x0
	[CompilerGenerated]
	private Bounds <Bounds>k__BackingField; //Field offset: 0x20
	private bool _isSceneLightIntensityDirty; //Field offset: 0x38
	private float _sceneLightIntensity; //Field offset: 0x3C
	private bool _shouldUpdateSceneLights; //Field offset: 0x40
	private bool _shouldUpdateDynamicLights; //Field offset: 0x41
	public readonly HashSet<LightSource> LightSourceSet; //Field offset: 0x48
	public readonly HashSet<LitBase> LitSet; //Field offset: 0x50
	public readonly HashSet<LitBase> LitReceiveDynamicSet; //Field offset: 0x58

	public private Bounds Bounds
	{
		[CompilerGenerated]
		 get { } //Length: 20
		[CompilerGenerated]
		private set { } //Length: 20
	}

	private static LightArea() { }

	public LightArea() { }

	private void Awake() { }

	[CompilerGenerated]
	public Bounds get_Bounds() { }

	public float GetCurrentSceneLightIntensity() { }

	private float GetDistance(LightSource lightSource, LitBase lit) { }

	private float GetDynamicIntensityToAdd(LightSource lightSource, float distance) { }

	public void InitBounds() { }

	private bool IsDistanceEnoughForDynamicLight(LightSource lightSource, float distance) { }

	public void LightLateUpdate() { }

	private void OnDestroy() { }

	[CompilerGenerated]
	private void set_Bounds(Bounds value) { }

	public void SetSceneIntensityDirty() { }

	private void UpdateAllDynamicLightsInternal() { }

	public void UpdateAllLights() { }

	public void UpdateDynamicLightOnLit(LitBase lit) { }

	public void UpdateDynamicLights() { }

	public void UpdateSceneLightOnLit(LitBase lit) { }

	public void UpdateSceneLights() { }

	private void UpdateSceneLightsInternal() { }

}

