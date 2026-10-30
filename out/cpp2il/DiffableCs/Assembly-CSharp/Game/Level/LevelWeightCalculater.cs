namespace Game.Level;

public class LevelWeightCalculater : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	private const string KETTLEBELL_LABEL = "Kettlebell_L13"; //Field offset: 0x0
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	protected TextMesh _textMesh; //Field offset: 0x28
	[SerializeField]
	private Single[] _weightTarget; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _onWeightTargetEvent; //Field offset: 0x38
	[SerializeField]
	private string _soundName; //Field offset: 0x40
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x48
	public float _weight; //Field offset: 0x50
	private int _weightIndex; //Field offset: 0x54

	public LevelWeightCalculater() { }

	private void Awake() { }

	public void ChangeWeightLimit() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private float GetWeight() { }

	private float GetWeight(LevelItem levelItem) { }

	public bool IsWeightInRange(LevelItem levelItem) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SetScale(LevelDropArea dropArea, LevelItem levelItem) { }

	public void TryFireWeightTargetEvent(LevelItem levelItem) { }

}

