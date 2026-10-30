namespace Game.Level;

[AddComponentMenu(null)]
public class LevelJugIndicator : LevelDragActionItemHandlerBase
{
	[SerializeField]
	private LevelDrinkableWithFillItemHandler _myHandler; //Field offset: 0xA0
	[SerializeField]
	private LevelJugContainer _container; //Field offset: 0xA8
	private readonly List<ILevelFillable> _targets; //Field offset: 0xB0

	public LevelJugIndicator() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer, ExitReasonType exitReasonType) { }

}

