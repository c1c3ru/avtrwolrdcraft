namespace PWC.Level;

public class LevelDoor : InteractableItem, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject, ILevelMakerDisabledWhileInEditMode, ILevelMakerUIMenuItem, ICanListenForSecrets
{
	[SerializeField]
	protected GameObject _opened; //Field offset: 0x40
	[SerializeField]
	protected GameObject _closed; //Field offset: 0x48
	[SerializeField]
	protected string _onSound; //Field offset: 0x50
	[SerializeField]
	protected string _offSound; //Field offset: 0x58
	[SerializeField]
	protected UnityEvent _onOpenEvent; //Field offset: 0x60
	[SerializeField]
	protected UnityEvent _onCloseEvent; //Field offset: 0x68
	protected bool _isOpen; //Field offset: 0x70
	public Action<Boolean> OnDoorChangeStateAction; //Field offset: 0x78
	public Func<Boolean> CanOpenDoorAction; //Field offset: 0x80
	[CompilerGenerated]
	private Action OnFailedToOpenDoorAction; //Field offset: 0x88

	public event Action OnFailedToOpenDoorAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public bool IsOpen
	{
		 get { } //Length: 8
	}

	public LevelDoor() { }

	[CompilerGenerated]
	public void add_OnFailedToOpenDoorAction(Action value) { }

	protected virtual void Awake() { }

	public void ForceClose() { }

	public void ForceOpen() { }

	public bool get_IsOpen() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private override void PWC.Level.ICanListenForSecrets.OnSecretSolvedHandler() { }

	private override void PWC.Level.ICanListenForSecrets.OnSecretUnsolvedHandler() { }

	private override void PWC.Level.Maker.ILevelMakerUIMenuItem.OnCreatedInsideUIItem() { }

	[CompilerGenerated]
	public void remove_OnFailedToOpenDoorAction(Action value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void ToggleState() { }

	public override void ToggleState(bool silent = false) { }

}

