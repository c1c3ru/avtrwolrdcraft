namespace PazuPaint;

public class LTexture
{
	public Color32[] colors; //Field offset: 0x10
	[CompilerGenerated]
	private Texture2D <MyTexture>k__BackingField; //Field offset: 0x18
	public int width; //Field offset: 0x20
	public int height; //Field offset: 0x24

	public private Texture2D MyTexture
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	private LTexture(int width, int height) { }

	private LTexture(LTexture texture) { }

	private LTexture(Texture2D texture, bool isArrayOnly) { }

	private LTexture(Texture2D texture, Rect rect) { }

	public void Apply() { }

	public void Clear(bool destroyUnityTextureIfExists = true) { }

	public static LTexture Create(Texture2D texture) { }

	public static LTexture CreateArrayOnly(Texture2D texture, Rect rect) { }

	public static LTexture CreateArrayOnly(Texture2D texture) { }

	public static LTexture CreateArrayOnly(LTexture lTexture) { }

	public static LTexture CreateArrayOnly(int width, int height) { }

	[CompilerGenerated]
	public Texture2D get_MyTexture() { }

	private Color32[] GetColorsCopy() { }

	public Color32 GetPixel(int x, int y) { }

	public Color32[] GetPixels() { }

	public void GetPixels(Color32[] arrayTofill) { }

	public Color32[] GetPixels(int x, int y, int width, int height) { }

	public void GetPixels(int x, int y, int width, int height, Color32[] arrayToFill) { }

	[CompilerGenerated]
	private void set_MyTexture(Texture2D value) { }

	public void SetPixel(int x, int y, Color32 color) { }

	public void SetPixels(Color32[] colors) { }

	public void SetPixels(int x, int y, int width, int height, Color32[] colors) { }

}

