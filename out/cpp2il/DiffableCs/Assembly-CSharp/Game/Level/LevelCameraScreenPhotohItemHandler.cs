namespace Game.Level;

[RequireComponent(typeof(LevelItem))]
public class LevelCameraScreenPhotohItemHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	protected SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	protected UnityEvent OnZoomIn; //Field offset: 0x28
	[SerializeField]
	protected UnityEvent OnZoomOut; //Field offset: 0x30
	private string _texturePath; //Field offset: 0x38
	private bool _isZoomedIn; //Field offset: 0x40
	private bool _shouldZoomInOnEndLand; //Field offset: 0x41
	private Vector2 _positionBeforeZoom; //Field offset: 0x44
	private Transform _parentBeforeZoom; //Field offset: 0x50
	private int _sortingOrderBeforeZoom; //Field offset: 0x58
	protected LevelItem _levelItem; //Field offset: 0x60
	private Camera _camera; //Field offset: 0x68

	public string TextureName
	{
		 get { } //Length: 8
	}

	public LevelCameraScreenPhotohItemHandler() { }

	protected override void Awake() { }

	public string get_TextureName() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	protected override void OnBeforeDestroyWhileInGameplay(LevelItem levelItem) { }

	protected override void OnDestroy() { }

	protected override void OnEndLand(LevelDropArea dropArea) { }

	private void OnGameCameraPointerDown() { }

	public override void OnPointerClick(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	public void OnSpawnFromCamera(PointerEventData eventData, bool shouldZoomInOnEndLand) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public override void SetTexture(Texture2D texture, string spritePath) { }

	private void Start() { }

	private void ZoomIn() { }

}

