namespace UnityEngine;

[NativeHeader("Runtime/Graphics/Texture.h")]
[NativeHeader("Runtime/Streaming/TextureStreamingManager.h")]
[UsedByNativeCode]
public class Texture : object
{
	public static readonly int GenerateAllMips; //Field offset: 0x0

	internal ColorSpace activeTextureColorSpace
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule", "Unity.UIElements"})]
		internal get { } //Length: 72
	}

	public int anisoLevel
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public FilterMode filterMode
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public override int height
	{
		 get { } //Length: 60
		 set { } //Length: 56
	}

	public override bool isReadable
	{
		 get { } //Length: 60
	}

	public float mipMapBias
	{
		 set { } //Length: 76
	}

	public Vector2 texelSize
	{
		[NativeName("GetTexelSize")]
		 get { } //Length: 76
	}

	public override int width
	{
		 get { } //Length: 60
		 set { } //Length: 56
	}

	public TextureWrapMode wrapMode
	{
		[NativeName("GetWrapModeU")]
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public TextureWrapMode wrapModeU
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public TextureWrapMode wrapModeV
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public TextureWrapMode wrapModeW
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	private static Texture() { }

	protected Texture() { }

	internal UnityException CreateNativeArrayLengthOverflowException() { }

	internal UnityException CreateNonReadableException(Texture t) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule", "Unity.UIElements"})]
	internal ColorSpace get_activeTextureColorSpace() { }

	public int get_anisoLevel() { }

	public FilterMode get_filterMode() { }

	public override int get_height() { }

	public override bool get_isReadable() { }

	[NativeName("GetTexelSize")]
	public Vector2 get_texelSize() { }

	private void get_texelSize_Injected(out Vector2 ret) { }

	public override int get_width() { }

	[NativeName("GetWrapModeU")]
	public TextureWrapMode get_wrapMode() { }

	public TextureWrapMode get_wrapModeU() { }

	public TextureWrapMode get_wrapModeV() { }

	public TextureWrapMode get_wrapModeW() { }

	private int GetDataHeight() { }

	private int GetDataWidth() { }

	internal TextureColorSpace GetTextureColorSpace(bool linear) { }

	internal TextureColorSpace GetTextureColorSpace(GraphicsFormat format) { }

	[NativeMethod("GetActiveTextureColorSpace")]
	private int Internal_GetActiveTextureColorSpace() { }

	public void set_anisoLevel(int value) { }

	public void set_filterMode(FilterMode value) { }

	public override void set_height(int value) { }

	public void set_mipMapBias(float value) { }

	public override void set_width(int value) { }

	public void set_wrapMode(TextureWrapMode value) { }

	public void set_wrapModeU(TextureWrapMode value) { }

	public void set_wrapModeV(TextureWrapMode value) { }

	public void set_wrapModeW(TextureWrapMode value) { }

	internal bool ValidateFormat(TextureFormat format) { }

	internal bool ValidateFormat(GraphicsFormat format, FormatUsage usage) { }

}

