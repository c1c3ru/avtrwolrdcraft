namespace PWC.Level;

public class LevelSpriteVariantsHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private string _spritesFolder; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x28
	private string _spriteName; //Field offset: 0x30
	public Action<Sprite> OnSpriteSetAction; //Field offset: 0x38

	public LevelSpriteVariantsHandler() { }

	private string GetFolderPath() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public Sprite[] GetSprites() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetSprite(Sprite sprite) { }

}

