namespace PWC.Level;

public class LevelParticleSystemOnCharacterAreaItemHandler : LevelDragActionCharacterAreaItemHandlerBase
{
	[SerializeField]
	private AreaType _areaType; //Field offset: 0xA0
	[SerializeField]
	protected ParticleSystem _particleSystem; //Field offset: 0xA8
	private int _numberOfCharacters; //Field offset: 0xB0

	public LevelParticleSystemOnCharacterAreaItemHandler() { }

	public virtual AreaType GetAreaTypeToCheck() { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer, ExitReasonType exitReasonType) { }

}

