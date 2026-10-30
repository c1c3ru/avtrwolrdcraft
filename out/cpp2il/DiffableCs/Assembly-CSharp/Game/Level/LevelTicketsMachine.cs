namespace Game.Level;

[AddComponentMenu(null)]
public class LevelTicketsMachine : LevelConsumerAreaBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__4_1; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <Operate>b__4_1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public LevelItem levelItem; //Field offset: 0x10
		public LevelTicketsMachine <>4__this; //Field offset: 0x18
		public Action <>9__2; //Field offset: 0x20

		public <>c__DisplayClass4_0() { }

		internal void <Operate>b__0() { }

		internal void <Operate>b__2() { }

	}

	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x58
	[SerializeField]
	private PDPrefabReference _prefab; //Field offset: 0x60
	[SerializeField]
	private Transform _entryPoint; //Field offset: 0x68
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x70

	public LevelTicketsMachine() { }

	public void Operate(LevelItem levelItem) { }

	private void SpawnTicket() { }

}

