namespace Game.Level;

public class LevelFillableJugIndicator : LevelDragActionItemHandlerBase
{
	[SerializeField]
	private GameObject _fillableGameObject; //Field offset: 0xA0
	[SerializeField]
	private LevelFillableJugContainer _container; //Field offset: 0xA8
	private readonly List<ILevelFillable> _targets; //Field offset: 0xB0
	private ILevelFillable _fillable; //Field offset: 0xB8

	public LevelFillableJugIndicator() { }

	protected virtual void Awake() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer, ExitReasonType exitReasonType) { }

}

