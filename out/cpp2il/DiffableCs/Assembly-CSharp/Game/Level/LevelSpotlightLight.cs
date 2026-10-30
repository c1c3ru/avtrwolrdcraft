namespace Game.Level;

[DisallowMultipleComponent]
public class LevelSpotlightLight : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject, IPointerDownHandler
{
	[SerializeField]
	private LitSpriteRenderer _litSpriteRenderer; //Field offset: 0x20
	[SerializeField]
	private LightSource _lightSource; //Field offset: 0x28
	[SerializeField]
	private SpriteRenderer[] _spriteRenderers; //Field offset: 0x30
	[SerializeField]
	private Color[] _colors; //Field offset: 0x38
	private bool _isOn; //Field offset: 0x40
	private int _colorsCounter; //Field offset: 0x44

	public LevelSpotlightLight() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnLightManagerInited() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void Start() { }

	private void SyncState() { }

}

