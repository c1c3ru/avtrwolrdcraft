namespace BWYW;

public class BWYWClothingCondition : BWYWConditionBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<SkinData, String> <>9__1_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal string <IsValid>b__1_0(SkinData skin) { }

	}

	public List<String> clothesNames; //Field offset: 0x10

	public BWYWClothingCondition() { }

	public virtual bool IsValid(ILevelAvatar avatar) { }

}

