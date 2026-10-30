namespace PWC.AvatarSpine;

public static class AvatarSpineTexturesManager
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_0
	{
		public Texture2D texture; //Field offset: 0x10

		public <>c__DisplayClass1_0() { }

		internal bool <UpdateCounter>b__0(TextureData data) { }

		internal bool <UpdateCounter>b__1(TextureData data) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public string textureName; //Field offset: 0x10

		public <>c__DisplayClass2_0() { }

		internal bool <IsTextureExist>b__0(TextureData data) { }

	}

	private static Dictionary<SpineType, List`1<TextureData>> _textureDataBySpineType; //Field offset: 0x0

	private static AvatarSpineTexturesManager() { }

	public static void ClearAllTextureData() { }

	public static bool IsTextureExist(SpineType spineType, string textureName, out Texture2D texture) { }

	public static int UpdateCounter(bool value, Texture2D texture, SpineType spineType) { }

}

