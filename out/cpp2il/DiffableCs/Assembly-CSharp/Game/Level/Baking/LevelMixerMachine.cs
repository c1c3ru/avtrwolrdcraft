namespace Game.Level.Baking;

public class LevelMixerMachine : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	private const int TOPPING_INDEX_START_POSITION = 13; //Field offset: 0x0
	private const int UNNECESSERY_CLONE_SUFFIX_LENGTH = 7; //Field offset: 0x0
	private const int USES_UNTIL_DIRTY = 3; //Field offset: 0x0
	private const string TOPPINGS_SUFFIX = "_Dough_L20"; //Field offset: 0x0
	private const string TOPPINGS_PATH = "Food_BakeryToppings/Dough/"; //Field offset: 0x0
	private const int SPECIAL_TOPPING_INDEX_START_POSITION = 5; //Field offset: 0x0
	[SerializeField]
	private LevelDropArea _levelDropArea; //Field offset: 0x20
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x28
	[SerializeField]
	private string _workingGettingStainedSoundName; //Field offset: 0x30
	[SerializeField]
	private string _workingSoundName; //Field offset: 0x38
	[SerializeField]
	private LevelButton _button; //Field offset: 0x40
	[SerializeField]
	private GameObject _blocker; //Field offset: 0x48
	[SerializeField]
	private PDPrefabReference _doughPrefabReference; //Field offset: 0x50
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x58
	[SerializeField]
	private LevelItem _gift; //Field offset: 0x60
	[SerializeField]
	private UnityEvent _onCleanedEvent; //Field offset: 0x68
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private String[] _animationsNames; //Field offset: 0x70
	private bool _hasTopping; //Field offset: 0x78
	private bool _hasFlour; //Field offset: 0x79
	private bool _hasDough; //Field offset: 0x7A
	private bool _giftTaken; //Field offset: 0x7B
	private Color _currentColor; //Field offset: 0x7C
	private string _currentToppingName; //Field offset: 0x90
	private int _numOfUses; //Field offset: 0x98
	private bool _isDirty; //Field offset: 0x9C
	private Animation _cleanAnimation; //Field offset: 0xA0
	private Animation _idleCleanAnimation; //Field offset: 0xA8
	private Animation _idleDirtyAnimation; //Field offset: 0xB0
	private Animation _workingCleanAnimation; //Field offset: 0xB8
	private Animation _workingDirtyAnimation; //Field offset: 0xC0
	private Animation _workingStainedAnimation; //Field offset: 0xC8
	private bool _isWorking; //Field offset: 0xD0

	public LevelMixerMachine() { }

	[CompilerGenerated]
	private void <Mix>b__42_0(MPDataGeneratorHandle mpDataGeneratorHandle) { }

	[CompilerGenerated]
	private void <Mix>b__42_1(MPDataGeneratorHandle _) { }

	private void AddIdleAnimation() { }

	private void Awake() { }

	public void Clean() { }

	private void CreateDough() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private LevelSpawn GetPrefabToSpawn(PDPrefabReference _reference) { }

	private string GetToppingName(string prefabName) { }

	private bool IsDough(LevelEatableItemHandler levelItem) { }

	private bool IsFlour(LevelEatableItemHandler levelItem) { }

	private bool IsTopping(LevelEatableItemHandler levelItem) { }

	public void Mix() { }

	private void OnDestroy() { }

	private void OnItemDrop(LevelDropArea levelDropArea, LevelItem levelItem) { }

	private void OnItemPickUp(LevelDropArea levelDropArea, LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SetWorkingAnimation() { }

	private void UpdateContent() { }

}

