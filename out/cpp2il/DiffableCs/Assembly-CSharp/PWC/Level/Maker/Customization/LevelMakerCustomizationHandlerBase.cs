namespace PWC.Level.Maker.Customization;

public abstract class LevelMakerCustomizationHandlerBase : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject, ILevelSpawnDuringGameplay, IMultiplayer_IgnoreInputEvents
{
	private enum SetType
	{
		None = 0,
		Texture = 1,
		Color = 2,
		Sprite = 3,
	}

	[FormerlySerializedAs("_cofigName")]
	[SerializeField]
	private string _configName; //Field offset: 0x20
	[SerializeField]
	private Color _defaultColor; //Field offset: 0x28
	[SerializeField]
	private Texture2D _defaultTile; //Field offset: 0x38
	private LevelMakerCCMainGroup _config; //Field offset: 0x40
	private LevelMakerCustomizationPD _pdData; //Field offset: 0x48
	private SetType _lastSetType; //Field offset: 0x50

	public string ConfigName
	{
		 get { } //Length: 8
	}

	protected LevelMakerCustomizationHandlerBase() { }

	protected override bool AllowColorsWithTextures() { }

	public void ApplyDefaultColorIfExists() { }

	protected override void Awake() { }

	public string get_ConfigName() { }

	public string GetCategory() { }

	public Color GetColor() { }

	public LevelMakerCCMainGroup GetConfig() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public string GetSpritePath() { }

	public string GetTexturePath() { }

	protected override void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnReadyPostInit() { }

	private void OnUGCPostInit() { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

	public void SetColor(Color color) { }

	protected override void SetColorInternal(Color color) { }

	public void SetConfig(string configName) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetSprite(Sprite sprite, string path) { }

	protected override void SetSpriteInternal(Sprite sprite) { }

	public void SetTexture(Texture2D texture, string path) { }

	protected override void SetTextureInternal(Texture2D texture) { }

	public bool TryGetTexture(out Texture2D texture, out string texturePath) { }

}

