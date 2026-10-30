namespace PWC.Level;

public class LevelFoldedObjectHandler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	protected bool _isFolded; //Field offset: 0x20
	[SerializeField]
	private bool _foldWithAvatar; //Field offset: 0x21
	[SerializeField]
	private bool _foldWithItem; //Field offset: 0x22
	[SerializeField]
	protected List<GameObject> _unfoldedObjects; //Field offset: 0x28
	[SerializeField]
	private List<GameObject> _foldedObjects; //Field offset: 0x30
	[SerializeField]
	private string _onOpenSoundName; //Field offset: 0x38
	[SerializeField]
	private UnityEvent _onOpen; //Field offset: 0x40
	[SerializeField]
	private string _onCloseSoundName; //Field offset: 0x48
	[SerializeField]
	private UnityEvent _onClose; //Field offset: 0x50
	private List<IItemsHolderArea> _unfoldedItemsHolderAreas; //Field offset: 0x58
	private List<IItemsHolderArea> _foldedItemsHolderAreas; //Field offset: 0x60
	private bool _isFoldedInDataState; //Field offset: 0x68

	public bool IsFolded
	{
		 get { } //Length: 8
	}

	public LevelFoldedObjectHandler() { }

	[CompilerGenerated]
	private void <SyncGameObjectsToState>b__26_0(GameObject unfoldedObject) { }

	[CompilerGenerated]
	private void <SyncGameObjectsToState>b__26_1(GameObject foldedObject) { }

	private void Awake() { }

	private void CallEvents(bool isFolded) { }

	private bool CanFold() { }

	private void EnsureAreas() { }

	private void EnsureItemsHolderArea(List<GameObject> fromList, ref List<IItemsHolderArea>& areas) { }

	public bool get_IsFolded() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void OnPostInit() { }

	private void PlaySound(string soundName) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetState(bool isFolded) { }

	private void SyncGameObjectsToState() { }

	private void SyncState() { }

	private void ToggleState() { }

}

