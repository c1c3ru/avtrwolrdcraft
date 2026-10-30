//Type is in global namespace

public class LevelTractorShovel : LevelDragActionItemHandlerBase
{
	protected LevelDigArea _currentDigArea; //Field offset: 0xA0
	[SerializeField]
	private ParticleSystem _dirtParticles; //Field offset: 0xA8
	public UnityEvent OnDig; //Field offset: 0xB0

	public LevelTractorShovel() { }

	private void Dig() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual void OnTargetEnter(ILevelConsumer target) { }

	protected virtual void OnTargetExit(ILevelConsumer target, ExitReasonType exitReasonType) { }

	private void PlayParticles() { }

}

