namespace PWC.LightSystem;

public class LightSource : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	public static readonly List<LightSource> List; //Field offset: 0x0
	[SerializeField]
	private Color _color; //Field offset: 0x20
	[SerializeField]
	private float _radius; //Field offset: 0x30
	[SerializeField]
	private bool _affectSceneIntensity; //Field offset: 0x34
	private SpriteRenderer _spriteRenderer; //Field offset: 0x38
	private LightArea _lightArea; //Field offset: 0x40
	public float intensity; //Field offset: 0x48

	public bool AffectSceneIntensity
	{
		 get { } //Length: 8
	}

	private static LightSource() { }

	public LightSource() { }

	private void Awake() { }

	public void EnsureLightArea(bool updateLights = true) { }

	public bool get_AffectSceneIntensity() { }

	public Color GetColor() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public Vector2 GetPointForDistanceCheck() { }

	public float GetRadius() { }

	private bool IsInsideLightArea(LightArea lightArea) { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnEnable() { }

	public void SetColor(Color color) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void UpdateAreaLights() { }

}

