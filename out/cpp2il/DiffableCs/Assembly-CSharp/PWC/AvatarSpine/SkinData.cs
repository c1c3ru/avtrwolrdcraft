namespace PWC.AvatarSpine;

public class SkinData
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Color32, Color> <>9__5_0; //Field offset: 0x8
		public static Func<Color, Color32> <>9__9_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal Color32 <.ctor>b__9_0(Color x) { }

		internal Color <GetColorsWithFloatComponents>b__5_0(Color32 x) { }

	}

	public int CategoryType; //Field offset: 0x10
	public string SkinName; //Field offset: 0x18
	public Color32[] Colors; //Field offset: 0x20
	public Nullable<Color> ColorA; //Field offset: 0x28
	public Nullable<Color> ColorB; //Field offset: 0x3C

	public SkinData(SkinData other) { }

	public SkinData(int categoryType, string skinName, Color[] colors = null) { }

	[JsonConstructor]
	public SkinData() { }

	[CompilerGenerated]
	internal static bool <ClearColorsIfNotNeeded>g__IsClear|6_1(ref Color32 color) { }

	[CompilerGenerated]
	internal static bool <ClearColorsIfNotNeeded>g__IsWhite|6_0(ref Color32 color) { }

	private void ClearColorsIfNotNeeded() { }

	public Color[] GetColorsWithFloatComponents() { }

	[OnDeserialized]
	private void OnDeserialized(StreamingContext context) { }

}

