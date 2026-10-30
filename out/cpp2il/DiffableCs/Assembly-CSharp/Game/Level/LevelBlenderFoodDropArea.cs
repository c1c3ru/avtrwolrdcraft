namespace Game.Level;

public class LevelBlenderFoodDropArea : LevelFoodOnlyDropArea
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<LevelItem> <>9__6_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <OnBlenderBlending>b__6_0(LevelItem levelItem) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public LevelItem levelItem; //Field offset: 0x10

		public <>c__DisplayClass6_0() { }

		internal void <OnBlenderBlending>b__1() { }

	}

	[SerializeField]
	private LevelSpineBlender _blender; //Field offset: 0xE0
	private int _itemsCounter; //Field offset: 0xE8

	public LevelBlenderFoodDropArea() { }

	public void OnBlenderBlending() { }

	public virtual void OnItemBeginDrop(LevelItem levelItem) { }

	public virtual void OnItemEndDrop(LevelItem levelItem) { }

	public virtual void OnItemPickUp(LevelItem levelItem) { }

	protected virtual void OnLevelPostInit() { }

}

