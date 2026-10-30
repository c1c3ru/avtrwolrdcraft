namespace Game.Level;

public class LevelCameraScreenFilmRoll : LevelCameraScreenPhotohItemHandler
{
	[SerializeField]
	private List<SpriteRenderer> _spriteRenderers; //Field offset: 0x70
	private readonly int _MainTexID; //Field offset: 0x78
	private List<PDTexture2DReference> _texture2DReferences; //Field offset: 0x80
	private List<SpriteRenderer> _occupiedSpriteRenderers; //Field offset: 0x88

	public SpriteRenderer[] AvailableSpriteRenderers
	{
		 get { } //Length: 192
	}

	public SpriteRenderer[] OccupiedSpriteRenderers
	{
		 get { } //Length: 80
	}

	public LevelCameraScreenFilmRoll() { }

	[CompilerGenerated]
	private bool <get_AvailableSpriteRenderers>b__7_0(SpriteRenderer renderer) { }

	public void DeleteSavedTextures() { }

	public SpriteRenderer[] get_AvailableSpriteRenderers() { }

	public SpriteRenderer[] get_OccupiedSpriteRenderers() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnBeforeDestroyWhileInGameplay(LevelItem levelItem) { }

	private string SaveTexture(Texture2D texture) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public virtual void SetTexture(Texture2D texture, string spritePath) { }

	public bool TryAddTexture(Texture2D texture) { }

}

