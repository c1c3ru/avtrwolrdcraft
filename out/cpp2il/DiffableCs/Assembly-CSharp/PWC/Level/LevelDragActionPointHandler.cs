namespace PWC.Level;

[DisallowMultipleComponent]
public class LevelDragActionPointHandler : MonoBehaviour
{
	[SerializeField]
	private Transform _actionPoint; //Field offset: 0x20
	private Comparison<ILevelConsumer> _comparer; //Field offset: 0x28
	private ILevelConsumer _currentTarget; //Field offset: 0x30
	private LevelItem _levelItem; //Field offset: 0x38
	[CompilerGenerated]
	private Action<ILevelConsumer> OnTargetEnterAction; //Field offset: 0x40
	[CompilerGenerated]
	private Action<ILevelConsumer> OnTargetExitAction; //Field offset: 0x48
	private List<ILevelConsumer> _consumers; //Field offset: 0x50

	public event Action<ILevelConsumer> OnTargetEnterAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<ILevelConsumer> OnTargetExitAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LevelDragActionPointHandler() { }

	[CompilerGenerated]
	public void add_OnTargetEnterAction(Action<ILevelConsumer> value) { }

	[CompilerGenerated]
	public void add_OnTargetExitAction(Action<ILevelConsumer> value) { }

	public bool CanPerformDragInteraction(GameShape consumerGameShape) { }

	private void ExitCurrentTarget() { }

	public void FinishDragAction() { }

	public void Init(LevelItem levelItem) { }

	private void OnFailedToReachTarget() { }

	private void OnTargetEnter() { }

	private void OnTargetExit() { }

	public void PrepareConsumers() { }

	public static void Register(LevelDragActionPointHandler handler, Action<ILevelConsumer> onEnter, Action<ILevelConsumer> onExit) { }

	[CompilerGenerated]
	public void remove_OnTargetEnterAction(Action<ILevelConsumer> value) { }

	[CompilerGenerated]
	public void remove_OnTargetExitAction(Action<ILevelConsumer> value) { }

	public void RunDragItemLevelQuery() { }

	public static void Unregister(LevelDragActionPointHandler handler, Action<ILevelConsumer> onEnter, Action<ILevelConsumer> onExit) { }

}

