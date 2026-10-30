namespace PWC.Level;

public class LevelDragActionHandler : MonoBehaviour, IInteractableItem, IMultiplayer_NetworkIdentityBase
{
	internal enum ExitReasonType
	{
		None = 0,
		WhileDrag = 1,
		EndDrag = 2,
		OneTimeActionEnd = 3,
	}

	internal enum Multiplayer_EventType
	{
		None = 0,
		Enter = 1,
		Exit = 2,
	}

	internal sealed class Multiplayer_ShouldSendEnterAndExitEventsDelegate : MulticastDelegate
	{

		public Multiplayer_ShouldSendEnterAndExitEventsDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(ref bool value, AsyncCallback callback, object object) { }

		public override void EndInvoke(ref bool value, IAsyncResult result) { }

		public override void Invoke(ref bool value) { }

	}

	[SerializeField]
	private CShape _cShape; //Field offset: 0x20
	private Comparison<ILevelConsumer> _comparer; //Field offset: 0x28
	protected LevelItem _levelItem; //Field offset: 0x30
	[CompilerGenerated]
	private Action<ILevelConsumer> OnTargetEnterAction; //Field offset: 0x38
	[CompilerGenerated]
	private Action<ILevelConsumer, ExitReasonType> OnTargetExitAction; //Field offset: 0x40
	private GameShape _gameShape; //Field offset: 0x48
	private readonly HashSet<ILevelConsumer> _outConsumers; //Field offset: 0x50
	private readonly HashSet<ILevelConsumer> _currentConsumers; //Field offset: 0x58
	private readonly HashSet<ILevelConsumer> _consumersToExit; //Field offset: 0x60
	private List<ILevelConsumer> _consumers; //Field offset: 0x68
	private Predicate<ILevelConsumer> _currentFilter; //Field offset: 0x70
	private bool _isDragging; //Field offset: 0x78
	private bool _multiplayer_canSendEvent; //Field offset: 0x79
	private bool _multiplayer_hasPDSceneObject; //Field offset: 0x7A
	[CompilerGenerated]
	private int <Multiplayer_ComponentIndex>k__BackingField; //Field offset: 0x7C
	[CompilerGenerated]
	private Multiplayer_ShouldSendEnterAndExitEventsDelegate Multiplayer_ShouldSendEnterAndExitEventsAction; //Field offset: 0x80

	public event Multiplayer_ShouldSendEnterAndExitEventsDelegate Multiplayer_ShouldSendEnterAndExitEventsAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event Action<ILevelConsumer> OnTargetEnterAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<ILevelConsumer, ExitReasonType> OnTargetExitAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public override int Multiplayer_ComponentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public GameShape MyGameShape
	{
		 get { } //Length: 8
	}

	public LevelDragActionHandler() { }

	[CompilerGenerated]
	public void add_Multiplayer_ShouldSendEnterAndExitEventsAction(Multiplayer_ShouldSendEnterAndExitEventsDelegate value) { }

	[CompilerGenerated]
	public void add_OnTargetEnterAction(Action<ILevelConsumer> value) { }

	[CompilerGenerated]
	public void add_OnTargetExitAction(Action<ILevelConsumer, ExitReasonType> value) { }

	protected override void Awake() { }

	public bool CanPerformDragInteraction(ILevelConsumer consumer, bool isStrict = true) { }

	private void ExitCurrentTargets(ExitReasonType exitReasonType) { }

	public void FinishDragAction(ExitReasonType exitReasonType) { }

	[CompilerGenerated]
	public override int get_Multiplayer_ComponentIndex() { }

	public GameShape get_MyGameShape() { }

	public void Init(LevelItem levelItem) { }

	public void Multiplayer_PostAction() { }

	public void Multiplayer_PreAction() { }

	protected override bool Multiplayer_ShouldSendEnterAndExitEvents() { }

	private bool Multiplayer_ShouldSendEvent() { }

	public void OnBeginDrag(PointerEventData eventData) { }

	protected override void OnDestroy() { }

	private void OnDisable() { }

	public void OnEndDrag(PointerEventData eventData) { }

	private void OnPrefabRuntimeSpawn(PDPrefab prefabInstance, bool _) { }

	protected override void OnTargetEnterInternal(ILevelConsumer consumer) { }

	protected override void OnTargetExitInternal(ILevelConsumer consumer, ExitReasonType exitReasonType) { }

	public void PrepareConsumers(Predicate<ILevelConsumer> filter = null) { }

	private override void PWC.Multiplayer.MPDataHelper_ItemDragInteraction.IInteractableItem.Multiplayer_DragInteract(ILevelConsumer consumer, Multiplayer_EventType eventType, MPEventIdentifierData idData) { }

	public static void Register(LevelDragActionHandler handler, Action<ILevelConsumer> onEnter, Action<ILevelConsumer, ExitReasonType> onExit) { }

	[CompilerGenerated]
	public void remove_Multiplayer_ShouldSendEnterAndExitEventsAction(Multiplayer_ShouldSendEnterAndExitEventsDelegate value) { }

	[CompilerGenerated]
	public void remove_OnTargetEnterAction(Action<ILevelConsumer> value) { }

	[CompilerGenerated]
	public void remove_OnTargetExitAction(Action<ILevelConsumer, ExitReasonType> value) { }

	public void RunDragItemLevelQuery(Func<ILevelConsumer, Boolean> customCondition = null) { }

	[CompilerGenerated]
	public override void set_Multiplayer_ComponentIndex(int value) { }

	public static void Unregister(LevelDragActionHandler handler, Action<ILevelConsumer> onEnter, Action<ILevelConsumer, ExitReasonType> onExit) { }

}

