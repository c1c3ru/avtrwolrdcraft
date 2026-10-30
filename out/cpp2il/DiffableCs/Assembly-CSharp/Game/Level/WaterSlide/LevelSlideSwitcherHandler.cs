namespace Game.Level.WaterSlide;

public class LevelSlideSwitcherHandler : MonoBehaviour
{
	[SerializeField]
	private LevelSingleItemDropArea[] _dropAreas; //Field offset: 0x20
	[SerializeField]
	private LevelType _currentLevelType; //Field offset: 0x28
	[SerializeField]
	private LevelType _nextSceneLevelType; //Field offset: 0x2C
	[SerializeField]
	private bool _isInsideSlide; //Field offset: 0x30
	[SerializeField]
	private bool _includeRoot; //Field offset: 0x31

	public LevelSlideSwitcherHandler() { }

	private void Awake() { }

	public void LoadScene() { }

	private void OnBeforeSceneLoadStage1() { }

	private void OnDestroy() { }

	private void SaveItemInBulkData(out bool needToMoveToNextLevel) { }

	private void SetInSildeData(LevelItem levelItem, ref bool needToMoveToNextLevel) { }

}

