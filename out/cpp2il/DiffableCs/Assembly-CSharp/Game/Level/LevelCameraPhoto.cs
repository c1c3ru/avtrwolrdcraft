namespace Game.Level;

public class LevelCameraPhoto : LevelItem
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x348
	private string _spriteName; //Field offset: 0x350
	private string _spritePath; //Field offset: 0x358

	public LevelCameraPhoto() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetSprite(Sprite sprite, string spritePath) { }

}

