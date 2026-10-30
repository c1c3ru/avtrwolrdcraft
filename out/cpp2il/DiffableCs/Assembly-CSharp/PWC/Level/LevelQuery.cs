namespace PWC.Level;

public static class LevelQuery
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<ILevelConsumer> <>9__1_0; //Field offset: 0x8
		public static Predicate<ILevelConsumer> <>9__1_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal bool <TryRunDropItemLevelQuery>b__1_0(ILevelConsumer x) { }

		internal bool <TryRunDropItemLevelQuery>b__1_1(ILevelConsumer x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public Transform transfrom; //Field offset: 0x10

		public <>c__DisplayClass2_0() { }

		internal int <CreateComparer>b__0(ILevelConsumer lhs, ILevelConsumer rhs) { }

	}

	internal class DropQueryResult
	{
		public ILevelConsumer consumer; //Field offset: 0x10
		public bool isTouchOnly; //Field offset: 0x18

		public DropQueryResult() { }

	}


	public static Comparison<ILevelConsumer> CreateComparer(Transform transfrom) { }

	public static void TryRunCustomDragItemLevelQuery(List<ILevelConsumer> consumers, Func<ILevelConsumer, Boolean> condition, GameShape gameShape, HashSet<ILevelConsumer> outConsumers) { }

	public static void TryRunDragItemLevelQuery(List<ILevelConsumer> consumers, LevelItem item, GameShape gameShape, HashSet<ILevelConsumer> outConsumers) { }

	public static bool TryRunDropItemLevelQuery(LevelItem levelItem, out DropQueryResult outResult) { }

	public static bool TryRunPointDragItemLevelQuery(List<ILevelConsumer> consumers, LevelItem item, Vector2 point, out ILevelConsumer outConsumer) { }

}

