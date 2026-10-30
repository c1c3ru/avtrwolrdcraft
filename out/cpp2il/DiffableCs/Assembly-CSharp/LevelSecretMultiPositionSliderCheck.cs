//Type is in global namespace

public class LevelSecretMultiPositionSliderCheck : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelEventCounterHandler _eventCounterHandler; //Field offset: 0x20
	[SerializeField]
	private int correctIndex; //Field offset: 0x28
	private bool _isCorrect; //Field offset: 0x2C
	private LevelMultiPositionSlider _levelOnActionMoveObject; //Field offset: 0x30

	public LevelSecretMultiPositionSliderCheck() { }

	public void CheckPosition() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

