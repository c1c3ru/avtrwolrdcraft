namespace Game.Level;

[AddComponentMenu(null)]
public class LevelCoffeeMachineCoffeeCupItemHandler : MonoBehaviour
{
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer _front; //Field offset: 0x28
	[SerializeField]
	private LevelFillableItemHandler _fillableItemHandler; //Field offset: 0x30
	private string _backSpritePath; //Field offset: 0x38
	private string _frontSpritePath; //Field offset: 0x40

	public ILevelFillable FillableItemHandler
	{
		 get { } //Length: 8
	}

	public LevelItem LevelItem
	{
		 get { } //Length: 8
	}

	public LevelCoffeeMachineCoffeeCupItemHandler() { }

	public ILevelFillable get_FillableItemHandler() { }

	public LevelItem get_LevelItem() { }

	private void GetAndSetSprites() { }

	public Dictionary<String, Object> GetPersistentData() { }

	public void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetSprites(Sprite sprite, Sprite frontSprite) { }

	public void SetSpritesPaths(string spritePath, string frontSpritePath) { }

}

