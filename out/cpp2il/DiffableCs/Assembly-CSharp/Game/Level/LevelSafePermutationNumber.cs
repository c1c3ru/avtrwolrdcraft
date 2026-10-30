namespace Game.Level;

public class LevelSafePermutationNumber : LevelStationaryItem, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private int _targetNumber; //Field offset: 0x60
	[SerializeField]
	private int _minValue; //Field offset: 0x64
	[SerializeField]
	private int _maxValue; //Field offset: 0x68
	[SerializeField]
	private string _soundName; //Field offset: 0x70
	private int _number; //Field offset: 0x78
	private LevelSafe _safe; //Field offset: 0x80

	public LevelSafePermutationNumber() { }

	public int GetNumber() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public void Init(LevelSafe safe) { }

	public bool IsTargetNumber() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

