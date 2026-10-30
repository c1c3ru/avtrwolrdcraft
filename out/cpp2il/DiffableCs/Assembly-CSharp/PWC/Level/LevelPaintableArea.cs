namespace PWC.Level;

public class LevelPaintableArea : LevelConsumerAreaBase, IHasPersistentData, IRequirePDSceneObject, IHasSceneGuidUsedOutsideOfLevel, ILevelPaintableTarget, ILevelMakerUIMenuItem
{
	[SerializeField]
	private PaintableTexture _paintableTexture; //Field offset: 0x58
	private SpriteRenderer _spriteRenderer; //Field offset: 0x60
	private string _texturePath; //Field offset: 0x68
	private bool _isDirty; //Field offset: 0x70
	private PDSceneObject _sceneObject; //Field offset: 0x78
	private LTexture _brush; //Field offset: 0x80
	private LevelMakerItem _levelMakerItem; //Field offset: 0x88

	public LevelPaintableArea() { }

	protected virtual void Awake() { }

	public override void DisablePainting() { }

	public override void EnablePainting(Color color, LTexture brush) { }

	private void EnsureFolder() { }

	private string GetImagesDirectory() { }

	public PaintableTexture GetPaintableTexture() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private string GetTexturePath() { }

	private void Init() { }

	protected virtual void OnDestroy() { }

	private void OnPreSaveProgressAction(Scene scene) { }

	private void OnSyncMakerItemIsFlippedState(LevelMakerItem levelMakerItem, bool isFlipped) { }

	public override void Paint(Vector2 position) { }

	private override void PWC.Level.Maker.ILevelMakerUIMenuItem.OnCreatedInsideUIItem() { }

	public void ResetTexture(Texture2D textureToPaintOn = null) { }

	private void SaveTextureToDiskIfNeeded() { }

	public void SetBrush(LTexture brush) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetTexture(Texture2D texture, string texturePath) { }

}

