namespace Game.Level.TimedLocker;

public class LevelTimedLockerSlot : LevelConsumerAreaBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public LevelLockerCard card; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18
		public LevelTimedLockerSlot <>4__this; //Field offset: 0x20
		public Action <>9__1; //Field offset: 0x28

		public <>c__DisplayClass4_0() { }

		internal void <TryLevelItemDropInteraction>b__0() { }

		internal void <TryLevelItemDropInteraction>b__1() { }

	}

	[SerializeField]
	private LevelTimedLocker _timedLocker; //Field offset: 0x58
	[SerializeField]
	private LevelDoor _locker; //Field offset: 0x60
	[SerializeField]
	private Transform _point; //Field offset: 0x68
	[SerializeField]
	private string _soundName; //Field offset: 0x70

	public LevelTimedLockerSlot() { }

	public virtual bool TryLevelItemDropInteraction(LevelItem levelItem, out MPEventIdentifierData mpData) { }

}

