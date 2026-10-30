namespace Game.Level.ContextualAnimation;

public class LevelCALongBalloonAnimalShapingItemHandler : LevelCAItemHandlerBase
{
	private enum BalloonType
	{
		Birthday = 0,
		Princess = 1,
		Dinosaur = 2,
	}

	[SerializeField]
	private PDPrefabReference[] _balloons; //Field offset: 0x88
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x90
	[SerializeField]
	private LevelRuntimeColoredSpriteHandler _levelRuntimeColoredSprite; //Field offset: 0x98
	[SerializeField]
	private BalloonType _balloonType; //Field offset: 0xA0
	private readonly List<LevelCAConfig> _birthdayConfigs; //Field offset: 0xA8
	private readonly List<LevelCAConfig> _princessConfigs; //Field offset: 0xB0
	private readonly List<LevelCAConfig> _dinosaurConfigs; //Field offset: 0xB8
	private int _index; //Field offset: 0xC0

	public LevelCALongBalloonAnimalShapingItemHandler() { }

	public virtual bool AllowReturnToIdleAnimationWhenRemovedFromTarget() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	private LevelSpawn GetPrefabToSpawn(PDPrefabReference _reference) { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

