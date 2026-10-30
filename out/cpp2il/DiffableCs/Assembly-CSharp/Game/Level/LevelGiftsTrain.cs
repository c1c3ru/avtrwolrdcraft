namespace Game.Level;

public class LevelGiftsTrain : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	private const float VANISH_X_POSITION = 38,03; //Field offset: 0x0
	private const float BEFORE_TOWER_X_POSITION = 18,01; //Field offset: 0x0
	private const float TOWER_X_POSITION = 22,21; //Field offset: 0x0
	[SerializeField]
	private PDPrefabReference[] _giftsPrefabReferences; //Field offset: 0x20
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x28
	[SerializeField]
	private string _trainMovingSoundName; //Field offset: 0x30
	[SerializeField]
	private string _trainWhistleSoundName; //Field offset: 0x38
	[SerializeField]
	private int _interval; //Field offset: 0x40
	[SerializeField]
	private LevelDropArea _giftDropArea; //Field offset: 0x48
	[SerializeField]
	private LevelDropArea _locomotiveDropArea; //Field offset: 0x50
	[SerializeField]
	private LevelSitArea _sitArea; //Field offset: 0x58
	private bool _isMoving; //Field offset: 0x60
	private bool _isInit; //Field offset: 0x61
	private bool _didTimePass; //Field offset: 0x62
	private int _index; //Field offset: 0x64
	private DateTime _lastTimeGiftTaken; //Field offset: 0x68
	private string _currentPresentGuid; //Field offset: 0x70
	private int _movingOutTweenId; //Field offset: 0x78
	private int _movingInTweenId; //Field offset: 0x7C
	private int _movingInDelayTweenId; //Field offset: 0x80

	public LevelGiftsTrain() { }

	[CompilerGenerated]
	private void <GoOutOfScreen>b__25_0() { }

	[CompilerGenerated]
	private void <OnItemPickUp>b__24_0() { }

	[CompilerGenerated]
	private void <ReturnToCastle>b__27_0() { }

	[CompilerGenerated]
	private void <ReturnToCastle>b__27_1() { }

	[CompilerGenerated]
	private void <StartCircleAround>b__26_0() { }

	private void Awake() { }

	private void CalculateIsEnoughTimePassed() { }

	private void GetGiftIfNeeded() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void GoOutOfScreen(Action action) { }

	private void Init() { }

	private void OnDestroy() { }

	private void OnItemPickUp(LevelItem item) { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void ReturnToCastle() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SpawnGift() { }

	private void StartCircleAround() { }

}

