namespace Game.Level;

public class LevelSlidingCatShelf : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	private const float KETTLEBELL_WIGHT = 1,25; //Field offset: 0x0
	private const string KETTLEBELL_LABEL = "Kettlebell_L13"; //Field offset: 0x0
	[SerializeField]
	private GameObject _movingGameObject; //Field offset: 0x20
	[SerializeField]
	private float _upValue; //Field offset: 0x28
	[SerializeField]
	private float _downValue; //Field offset: 0x2C
	[SerializeField]
	private float _MinValueWithKettlebell; //Field offset: 0x30
	[SerializeField]
	private LevelDropArea[] _shelfDropAreas; //Field offset: 0x38
	[SerializeField]
	private LevelDropArea _innerShelfDropArea; //Field offset: 0x40
	[SerializeField]
	private UnityEvent _onSecretSolved; //Field offset: 0x48
	private bool _isMoving; //Field offset: 0x50
	private float _lastDestination; //Field offset: 0x54
	private int _tweenId; //Field offset: 0x58
	private float _defaultMinValue; //Field offset: 0x5C

	public LevelSlidingCatShelf() { }

	[CompilerGenerated]
	private void <OnItemDropOnShelf>b__16_0() { }

	[CompilerGenerated]
	private void <OnItemPickUpFromShelf>b__17_0() { }

	private void Awake() { }

	private float GetItemWight(LevelItem levelItem) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnItemDropOnShelf(LevelItem levelItem) { }

	private void OnItemPickUpFromShelf(LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

