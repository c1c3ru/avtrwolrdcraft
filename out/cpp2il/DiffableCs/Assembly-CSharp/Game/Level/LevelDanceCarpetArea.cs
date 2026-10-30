namespace Game.Level;

public class LevelDanceCarpetArea : LevelAnimationDropArea
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<LevelItem> <>9__5_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <IsCharacterChildExist>b__5_0(LevelItem levelItem) { }

	}

	[SerializeField]
	private LevelDanceCarpet _danceCarpet; //Field offset: 0xF8
	private bool _activateCarpetOnItemEndDrop; //Field offset: 0x100

	public LevelDanceCarpetArea() { }

	public bool IsCharacterChildExist() { }

	public virtual void OnItemBeginDrop(LevelItem levelItem) { }

	public virtual void OnItemEndDrop(LevelItem levelItem) { }

	public virtual void OnItemPickUp(LevelItem levelItem) { }

}

