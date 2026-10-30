namespace Game.Level;

public class LevelCustomIceCreamContainerItemHandler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	private const string BASE_TOPPING_NAME = "Level/IcecreamContainer/Food_Topping_Container_"; //Field offset: 0x0
	[SerializeField]
	private PDPrefabReference _icsCreamPrefab; //Field offset: 0x20
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x28
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x30
	[SerializeField]
	private string _soundName; //Field offset: 0x38
	[SerializeField]
	private int _maxNumberOfScoops; //Field offset: 0x40
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x48
	[SerializeField]
	private Sprite[] _containerFilledState; //Field offset: 0x50
	[SerializeField]
	private LevelFoodOnlyDropArea _LevelFoodOnlyDropArea; //Field offset: 0x58
	[SerializeField]
	private SpriteRenderer _topping; //Field offset: 0x60
	private int _currentNumberOfScoops; //Field offset: 0x68
	private Color _currentColor; //Field offset: 0x6C
	private string _toppingName; //Field offset: 0x80
	private string _toppingPrefabReference; //Field offset: 0x88

	public LevelCustomIceCreamContainerItemHandler() { }

	public void FillContainer(Color color, string toppingName, string toppingPrefabReference) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private LevelSpawn GetPrefabToSpawn() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void UpdateContainersSprite() { }

	public void UpdateToppingSprite() { }

}

