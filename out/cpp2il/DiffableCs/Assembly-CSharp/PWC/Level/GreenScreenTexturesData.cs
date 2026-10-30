namespace PWC.Level;

[CreateAssetMenu(fileName = "Green Screen Textures Data", menuName = "AvatarWorld/Level/Green Screen Textures Data")]
public class GreenScreenTexturesData : ScriptableObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public string label; //Field offset: 0x10

		public <>c__DisplayClass3_0() { }

		internal bool <TryGetTexture2DByLabel>b__0(GreenScreenTexture greenScreenTexture) { }

	}

	[SerializeField]
	private GreenScreenTexture[] _greenScreenTextures; //Field offset: 0x18

	public GreenScreenTexture[] GreenScreenTextures
	{
		 get { } //Length: 8
	}

	public GreenScreenTexturesData() { }

	public GreenScreenTexture[] get_GreenScreenTextures() { }

	public bool TryGetTexture2DByLabel(string label, out Texture2D texture2D) { }

}

