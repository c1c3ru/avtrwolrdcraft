namespace PazuPaint;

public static class TextureUtils
{

	public static void RotateLTexture(LTexture texture, float angle) { }

	private static Color32[] RotateLTextureSquare(Color32[] arr, float phi, LTexture originTexture) { }

	private static Color32[] RotateSquare(Color32[] arr, float phi, Texture2D originTexture) { }

	public static Texture2D RotateTexture(Texture2D originTexture, float angle, bool applyTexture) { }

	public static Texture2D ScaleTexture(Texture2D source, int targetWidth, int targetHeight, bool applyTexture, Nullable<TextureFormat> overrideTextureFormat = null) { }

	public static void ScaleTextureSelf(Texture2D texture, int targetWidth, int targetHeight, bool applyTexture) { }

}

