namespace PWC.Level;

[DisallowMultipleComponent]
public class LevelTwoStateHangHandler : LevelHangHandler, ILevelSpawnDuringGameplay, ILevelMakerUIMenuItem
{
	internal enum StateType
	{
		None = 0,
		Folded = 1,
		Hanged = 2,
	}

	[SerializeField]
	private CShape _hanged; //Field offset: 0x40
	[SerializeField]
	private CShape _folded; //Field offset: 0x48
	[SerializeField]
	private StateType _stateWhileDragging; //Field offset: 0x50
	[SerializeField]
	private StateType _stateInCharacterHand; //Field offset: 0x54
	private Renderer _foldedRenderer; //Field offset: 0x58
	private Renderer _hangedRenderer; //Field offset: 0x60
	private StateType _currentStateType; //Field offset: 0x68
	private bool _didEnsureStates; //Field offset: 0x6C

	public CShape Folded
	{
		 get { } //Length: 8
	}

	public CShape Hanged
	{
		 get { } //Length: 8
	}

	public LevelTwoStateHangHandler() { }

	protected virtual void Awake() { }

	private void EnsureStates() { }

	public CShape get_Folded() { }

	public CShape get_Hanged() { }

	public virtual void OnBeginDrag(PointerEventData eventData) { }

	protected virtual void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnPlacedOnAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	private void OnReadyPostLoad() { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

	private override void PWC.Level.Maker.ILevelMakerUIMenuItem.OnCreatedInsideUIItem() { }

	public void SetState(StateType stateType, bool whileDragging = false) { }

	public virtual bool TryHangOnConsumer(ILevelConsumer consumer) { }

	public bool TrySetFoldedState() { }

}

