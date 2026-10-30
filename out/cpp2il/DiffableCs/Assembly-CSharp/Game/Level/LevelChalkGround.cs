namespace Game.Level;

public class LevelChalkGround : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelPaintableArea _paintableArea; //Field offset: 0x20
	[SerializeField]
	private Texture2D[] _textures; //Field offset: 0x28
	[SerializeField]
	private int _overrideRandomTexturesLength; //Field offset: 0x30
	[SerializeField]
	private bool _supportsMasks; //Field offset: 0x34
	[SerializeField]
	private bool _ignorePD; //Field offset: 0x35
	[SerializeField]
	private bool _wasDrawnOnce; //Field offset: 0x36
	[SerializeField]
	private Texture2D _maskTexture; //Field offset: 0x38
	private LMask _lMask; //Field offset: 0x40
	private PaintableTexture _paintableTexture; //Field offset: 0x48
	private int _currentTextureIndex; //Field offset: 0x50

	public LevelChalkGround() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public void RemoveMask(LMask newMask, Vector2 maskWorldPosition) { }

	public void SetChalkTexture(int textureNumber) { }

	public void SetNextTexture() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetPreviousTexture() { }

	private void SetRandomChalkTexture() { }

	public void UpdateMask(LMask newMask, Vector2 maskWorldPosition) { }

}

