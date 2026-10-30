namespace PWC.Level;

public class LevelElectricGate : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler, IHasPersistentData, IRequirePDSceneObject
{
	internal enum StateType
	{
		None = 0,
		Open = 1,
		Opening = 2,
		Closed = 3,
		Closing = 4,
	}

	[SerializeField]
	private bool _ignorePD; //Field offset: 0x20
	[SerializeField]
	private float _movingSpeed; //Field offset: 0x24
	[SerializeField]
	private Vector2 _gateOpenPosition; //Field offset: 0x28
	[SerializeField]
	private Vector2 _gateClosedPosition; //Field offset: 0x30
	[SerializeField]
	private GameObject _gate; //Field offset: 0x38
	[SerializeField]
	private string _soundOpen; //Field offset: 0x40
	[SerializeField]
	private string _soundClose; //Field offset: 0x48
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x50
	protected StateType _currentState; //Field offset: 0x58
	private int _tweenId; //Field offset: 0x5C

	public LevelElectricGate() { }

	[CompilerGenerated]
	private void <CloseGate>b__17_0() { }

	[CompilerGenerated]
	private void <OpenGate>b__16_0() { }

	private void Awake() { }

	public void CloseGate() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void Init() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	public void OpenGate() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void StopTween() { }

	public void ToggleState() { }

}

