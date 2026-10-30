namespace Game.Level.Baking;

[DisallowMultipleComponent]
public class LevelBakeryToppingHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	public static readonly Dictionary<Int32, String> TOPPING_INDEX_TO_NAMES; //Field offset: 0x0
	[SerializeField]
	private SpriteRenderer _toppingRenderer; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer _sauceRenderer; //Field offset: 0x28
	[SerializeField]
	private SpriteRenderer _decorationsRenderer; //Field offset: 0x30
	[SerializeField]
	private LevelCookableSpawner _cookableSpawner; //Field offset: 0x38
	[SerializeField]
	private LevelCookableItemHandler _cookableItemHandler; //Field offset: 0x40
	private string _toppingPath; //Field offset: 0x48
	private string _toppingName; //Field offset: 0x50
	private string _unbakedSaucePath; //Field offset: 0x58
	private string _bakedSaucePath; //Field offset: 0x60
	private string _decorationPath; //Field offset: 0x68
	private string _sliceDecorationPath; //Field offset: 0x70
	private Color _sauceColor; //Field offset: 0x78

	private static LevelBakeryToppingHandler() { }

	public LevelBakeryToppingHandler() { }

	public void Awake() { }

	public string GetName() { }

	public static string GetNameFromIndex(int index) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private string GetSliceToppingPath() { }

	public void OnCook() { }

	public void OnDestroy() { }

	private void OnSpawn(LevelSpawn spawn) { }

	public void SetDecoration(string decorationPath, string sliceDecorationPath = null) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetSauce(Color color, string unbaked = null, string baked = null) { }

	public void SetToppingSprite(string path, string toppingName) { }

}

