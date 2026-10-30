namespace Game.Level;

public class LevelToyDollItemHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer _shoesRenderer; //Field offset: 0x28
	[SerializeField]
	private SpriteRenderer _shirtRenderer; //Field offset: 0x30
	[SerializeField]
	private SpriteRenderer _hatRenderer; //Field offset: 0x38
	[SerializeField]
	private Sprite[] _baseSprites; //Field offset: 0x40
	[SerializeField]
	private Sprite[] _shoesSprites; //Field offset: 0x48
	[SerializeField]
	private Sprite[] _shirtSprites; //Field offset: 0x50
	[SerializeField]
	private Sprite[] _hatSprites; //Field offset: 0x58
	private int _baseIndex; //Field offset: 0x60
	private int _shoesIndex; //Field offset: 0x64
	private int _shirtIndex; //Field offset: 0x68
	private int _hatIndex; //Field offset: 0x6C

	public LevelToyDollItemHandler() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public void SetIndices(int baseIndex, int shoesIndex, int shirtIndex, int hatIndex) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

