namespace Game.Level;

public class LevelLemonBasket : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private GameObject _movingGameObject; //Field offset: 0x20
	[SerializeField]
	private LevelDropArea _basketDropArea; //Field offset: 0x28
	[SerializeField]
	private LevelDropArea _couponDropArea; //Field offset: 0x30
	[SerializeField]
	private int _countValueForLift; //Field offset: 0x38
	[SerializeField]
	private int _countValueForLand; //Field offset: 0x3C
	[SerializeField]
	private float _upValue; //Field offset: 0x40
	[SerializeField]
	private float _downValue; //Field offset: 0x44
	public int _itemsCountOnDropArea; //Field offset: 0x48
	private bool _isMoving; //Field offset: 0x4C
	private bool _isFloating; //Field offset: 0x4D
	private bool _hasLanded; //Field offset: 0x4E
	private int _tweenId; //Field offset: 0x50

	public LevelLemonBasket() { }

	[CompilerGenerated]
	private void <AddToItemsCount>b__15_0() { }

	[CompilerGenerated]
	private void <RemoveFromItemsCount>b__16_0() { }

	private void AddToItemsCount(LevelItem levelItem) { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnPrePostInit() { }

	private void RemoveFromItemsCount(LevelItem levelItem) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

