namespace Game.Level;

public class LevelSafeWithoutSpine : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelSafePermutationSprite[] _numberButtons; //Field offset: 0x20
	[SerializeField]
	private GameObject _closedBox; //Field offset: 0x28
	[SerializeField]
	private GameObject _openedBox; //Field offset: 0x30
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x38
	[SerializeField]
	private string _openeSoundName; //Field offset: 0x40
	[SerializeField]
	private string _closedSoundName; //Field offset: 0x48
	[SerializeField]
	private UnityEvent _onSafeUnlocked; //Field offset: 0x50
	private bool _isUnlocked; //Field offset: 0x58
	private bool _isOpened; //Field offset: 0x59

	public LevelSafeWithoutSpine() { }

	protected void Awake() { }

	private bool CanOpenDoor() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void Init() { }

	private void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	protected override void PlaySound(string soundName) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void TryOpenSafe() { }

}

