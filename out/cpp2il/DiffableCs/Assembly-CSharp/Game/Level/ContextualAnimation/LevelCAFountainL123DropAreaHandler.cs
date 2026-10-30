namespace Game.Level.ContextualAnimation;

public class LevelCAFountainL123DropAreaHandler : LevelCADropAreaHandlerWithData
{
	[SerializeField]
	private LevelSpawn _coinPrefab; //Field offset: 0x98
	[SerializeField]
	private LevelSpawner _levelSpawner; //Field offset: 0xA0
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0xA8
	private LevelItem _currentCoin; //Field offset: 0xB0

	public LevelCAFountainL123DropAreaHandler() { }

	[CompilerGenerated]
	private void <OnAnimationEvent>b__4_0() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

