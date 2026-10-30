namespace Game.Level.ContextualAnimation;

public class LevelCAPutOnMakeupFromSpawnerItemHandlerWithData : LevelCAItemHandlerWithData
{
	[SerializeField]
	private LevelSimpleSpawnerBase _spawner; //Field offset: 0x90
	private LevelCharacter _levelCharacter; //Field offset: 0x98

	public LevelCAPutOnMakeupFromSpawnerItemHandlerWithData() { }

	protected virtual void Awake() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected virtual void OnDestroy() { }

	private void OnSpawnAction(LevelSimpleSpawnerBase spawnerBase, LevelSpawn levelSpawn) { }

}

