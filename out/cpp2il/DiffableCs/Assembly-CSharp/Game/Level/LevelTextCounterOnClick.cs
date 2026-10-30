namespace Game.Level;

public class LevelTextCounterOnClick : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private int _minValue; //Field offset: 0x20
	[SerializeField]
	private int _maxValue; //Field offset: 0x24
	[SerializeField]
	private TextMesh _textMesh; //Field offset: 0x28
	[SerializeField]
	private string _soundName; //Field offset: 0x30
	private int _counter; //Field offset: 0x38

	public LevelTextCounterOnClick() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	protected void IncreaseCount() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

