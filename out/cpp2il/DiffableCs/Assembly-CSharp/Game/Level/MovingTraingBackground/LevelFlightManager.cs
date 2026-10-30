namespace Game.Level.MovingTraingBackground;

public class LevelFlightManager : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private MovingBG _movingBG; //Field offset: 0x20
	[SerializeField]
	private LevelToggleableSprite[] _passageWindows; //Field offset: 0x28
	[SerializeField]
	private LevelAirplaneExitDoor[] _exitDoors; //Field offset: 0x30
	[SerializeField]
	private SpriteRenderer[] _flightButtons; //Field offset: 0x38
	[SerializeField]
	private Sprite[] _buttonSprites; //Field offset: 0x40
	[SerializeField]
	private LevelLevelSwitcher[] _levelSwitchers; //Field offset: 0x48
	[SerializeField]
	private LevelWorldType _destination; //Field offset: 0x50
	[SerializeField]
	private WorldBuildingType _buildingType; //Field offset: 0x54
	[SerializeField]
	private LevelType _levelType; //Field offset: 0x58
	private bool _isMoving; //Field offset: 0x5C
	private int _currentWorldIndex; //Field offset: 0x60

	public LevelFlightManager() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void Landing() { }

	private void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void OnTransitionEndStart() { }

	private void SetNewWorld() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SetTransitionState() { }

	private void TakeOff() { }

	private void UpdateIndex() { }

}

