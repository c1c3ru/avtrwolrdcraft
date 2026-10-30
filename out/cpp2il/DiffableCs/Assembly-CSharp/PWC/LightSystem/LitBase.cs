namespace PWC.LightSystem;

[DisallowMultipleComponent]
public abstract class LitBase : MonoBehaviour
{
	public static readonly List<LitBase> List; //Field offset: 0x0
	[SerializeField]
	private bool _receiveDynamicLight; //Field offset: 0x20
	public float intensity; //Field offset: 0x24
	public float dynamicIntensity; //Field offset: 0x28
	public Color dynamicLightColor; //Field offset: 0x2C
	public bool isDynamicDirty; //Field offset: 0x3C
	protected Color _color; //Field offset: 0x40
	private LightArea _lightArea; //Field offset: 0x50

	public bool ReceiveDynamicLight
	{
		 get { } //Length: 8
	}

	private static LitBase() { }

	protected LitBase() { }

	public abstract void ApplyIntensity() { }

	protected override void Awake() { }

	public void EnsureLightArea(bool updateLights = true) { }

	public bool get_ReceiveDynamicLight() { }

	public abstract Vector2 GetPointForDistanceCheck() { }

	protected abstract bool IsInsideLightArea(LightArea lightArea) { }

	public abstract bool IsVisible() { }

	private void OnBecameVisible() { }

	protected override void OnDestroy() { }

	protected override void OnDisable() { }

	protected override void OnEnable() { }

	public void RefreshAppearance() { }

	public void UpdateDynamicLight() { }

}

