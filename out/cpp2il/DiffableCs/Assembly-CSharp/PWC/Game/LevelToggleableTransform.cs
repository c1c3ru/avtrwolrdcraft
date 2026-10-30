namespace PWC.Game;

public class LevelToggleableTransform : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject, ILevelMakerDisabledWhileInEditMode
{
	internal class EventForIndex
	{
		[Header("Conditions")]
		public int index; //Field offset: 0x10
		[Header("Event")]
		[Space]
		public UnityEvent Event; //Field offset: 0x18

		public EventForIndex() { }

	}

	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x20
	[SerializeField]
	private bool _isRandom; //Field offset: 0x28
	[SerializeField]
	protected Transform[] _transforms; //Field offset: 0x30
	[SerializeField]
	private GameObject _movingObject; //Field offset: 0x38
	[SerializeField]
	private bool _isSetParent; //Field offset: 0x40
	[SerializeField]
	private String[] _transitionsSoundNames; //Field offset: 0x48
	protected int _currentIndex; //Field offset: 0x50
	public List<EventForIndex> OnClickActions; //Field offset: 0x58
	public List<EventForIndex> OnLoadPersistentDataActions; //Field offset: 0x60
	private CShape _cShape; //Field offset: 0x68

	public LevelToggleableTransform() { }

	[CompilerGenerated]
	private bool <OnPointerClick>b__12_0(EventForIndex x) { }

	[CompilerGenerated]
	private bool <SetPersistentData>b__16_0(EventForIndex x) { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	protected void PlaySound(string soundName) { }

	public void SetGameObjectActive(int index) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

