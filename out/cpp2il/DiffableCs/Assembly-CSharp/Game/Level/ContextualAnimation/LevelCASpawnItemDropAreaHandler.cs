namespace Game.Level.ContextualAnimation;

public class LevelCASpawnItemDropAreaHandler : LevelCADropAreaHandlerWithData
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public LevelCASpawnItemDropAreaHandler <>4__this; //Field offset: 0x10
		public int i; //Field offset: 0x18

		public <>c__DisplayClass8_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_1
	{
		public LevelSpawn prefab; //Field offset: 0x10
		public <>c__DisplayClass8_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass8_1() { }

		internal void <OnAnimationEvent>b__0() { }

	}

	[SerializeField]
	private List<LevelDropArea> _dropAreas; //Field offset: 0x98
	[SerializeField]
	private LevelSpawner _levelSpawner; //Field offset: 0xA0
	[SerializeField]
	private int _maxInstances; //Field offset: 0xA8
	[SerializeField]
	private bool _useFifo; //Field offset: 0xAC
	[SerializeField]
	private List<LevelSpawn> _prefabsToSpawn; //Field offset: 0xB0
	[Min(0)]
	[SerializeField]
	private float _delayBetweenItems; //Field offset: 0xB8
	[SerializeField]
	private bool _playPoofEffect; //Field offset: 0xBC
	[SerializeField]
	private bool _skipSpawnIfDropAreaOccupied; //Field offset: 0xBD

	public LevelCASpawnItemDropAreaHandler() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void SpawnItem(LevelSpawn prefab, int index) { }

	private bool TryGetTargetDropArea(int index, out LevelDropArea dropArea) { }

}

