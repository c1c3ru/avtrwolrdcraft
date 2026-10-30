namespace Game.Level;

public class LevelWeightHeightMeasureHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private GameObject _movingGameObject; //Field offset: 0x20
	[SerializeField]
	private float _minValue; //Field offset: 0x28
	[SerializeField]
	private float _maxValue; //Field offset: 0x2C
	[SerializeField]
	protected TextMesh _textMesh; //Field offset: 0x30
	[SerializeField]
	private string _soundName; //Field offset: 0x38
	[SerializeField]
	private bool _horizontal; //Field offset: 0x40
	[ConditionalField("_horizontal", False, True, (array) null)]
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x48
	[ConditionalField("_horizontal", True, True, (array) null)]
	[SerializeField]
	private LevelAvatarRestAreaBase _restArea; //Field offset: 0x50
	private int _tweenID; //Field offset: 0x58
	private float _factor; //Field offset: 0x5C
	private float _weight; //Field offset: 0x60

	public LevelWeightHeightMeasureHandler() { }

	private void Awake() { }

	private void DeleteText(LevelItem levelItem) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SetScaleHeight(LevelItem levelItem) { }

	private void SetScaleHeightHorizontal(LevelAvatarRestAreaBase area, ILevelAvatar avatar) { }

}

