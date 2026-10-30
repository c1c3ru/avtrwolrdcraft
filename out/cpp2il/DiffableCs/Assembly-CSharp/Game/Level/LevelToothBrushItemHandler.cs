namespace Game.Level;

public class LevelToothBrushItemHandler : LevelDragActionCharacterAreaItemHandlerBase
{
	[SerializeField]
	private GameObject _movingObject; //Field offset: 0xA0
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0xA8
	[SerializeField]
	private UnityEvent _onTargetEnterEvent; //Field offset: 0xB0
	[SerializeField]
	private UnityEvent _onTargetExitEvent; //Field offset: 0xB8
	private int _targetsCounter; //Field offset: 0xC0
	private bool _isPlayingTween; //Field offset: 0xC4
	private int _tweenID; //Field offset: 0xC8

	public LevelToothBrushItemHandler() { }

	protected virtual void Awake() { }

	public virtual AreaType GetAreaTypeToCheck() { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer, ExitReasonType exitReasonType) { }

	public void ParticleSystemSetActive(bool value) { }

}

