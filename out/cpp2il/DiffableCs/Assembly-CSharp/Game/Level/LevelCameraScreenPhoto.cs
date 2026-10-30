namespace Game.Level;

[AddComponentMenu(null)]
public class LevelCameraScreenPhoto : LevelItem
{
	[SerializeField]
	protected SpriteRenderer _spriteRenderer; //Field offset: 0x348
	[SerializeField]
	protected UnityEvent OnZoomIn; //Field offset: 0x350
	[SerializeField]
	protected UnityEvent OnZoomOut; //Field offset: 0x358
	[SerializeField]
	private float _scaleFactor; //Field offset: 0x360
	private string _texturePath; //Field offset: 0x368
	private bool _isZoomedIn; //Field offset: 0x370
	private bool _shouldZoomInOnEndLand; //Field offset: 0x371
	private Vector2 _positionBeforeZoom; //Field offset: 0x374
	private Transform _parentBeforeZoom; //Field offset: 0x380
	private int _sortingOrderBeforeZoom; //Field offset: 0x388

	public string TextureName
	{
		 get { } //Length: 8
	}

	public LevelCameraScreenPhoto() { }

	protected virtual void Awake() { }

	public string get_TextureName() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	public virtual void OnBeforeDestroyWhileInGameplay() { }

	protected virtual void OnDestroy() { }

	protected virtual LevelDropArea OnEndLand() { }

	private void OnGameCameraPointerDown() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	public void OnSpawnFromCamera(PointerEventData eventData, bool shouldZoomInOnEndLand) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public override void SetTexture(Texture2D texture, string spritePath) { }

	private void Start() { }

	private void ZoomIn() { }

}

