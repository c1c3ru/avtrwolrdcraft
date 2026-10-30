//Type is in global namespace

public class LevelSafeWithNumbers : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private TextMesh _leftCode; //Field offset: 0x20
	[SerializeField]
	private TextMesh _centerCode; //Field offset: 0x28
	[SerializeField]
	private TextMesh _rightCode; //Field offset: 0x30
	[SerializeField]
	private LevelDoor _door; //Field offset: 0x38
	[SerializeField]
	private LevelLockedDoorHandler _lockedDoorHandler; //Field offset: 0x40
	[Range(1, 10)]
	[SerializeField]
	private int _leftCodeSolution; //Field offset: 0x48
	[Range(1, 10)]
	[SerializeField]
	private int _centerCodeSolution; //Field offset: 0x4C
	[Range(1, 10)]
	[SerializeField]
	private int _rightCodeSolution; //Field offset: 0x50
	[SerializeField]
	private GameObject _pressButton; //Field offset: 0x58
	[SerializeField]
	private string _codeButtonSound; //Field offset: 0x60
	private bool _isSecretSolved; //Field offset: 0x68

	public LevelSafeWithNumbers() { }

	private bool CheckIfSecretSolved() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void IncreaseText(TextMesh text) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

