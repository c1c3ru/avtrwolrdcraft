namespace UnityEngine;

[NativeHeader("Runtime/Shaders/Material.h")]
[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
public class Material : object
{

	public Color color
	{
		 get { } //Length: 140
		 set { } //Length: 212
	}

	[NativeProperty("EnableInstancingVariants")]
	public bool enableInstancing
	{
		 set { } //Length: 68
	}

	public Texture mainTexture
	{
		 get { } //Length: 176
		 set { } //Length: 200
	}

	public Vector2 mainTextureOffset
	{
		 get { } //Length: 152
		 set { } //Length: 176
	}

	public int passCount
	{
		[NativeName("GetShader()->GetPassCount")]
		 get { } //Length: 60
	}

	public int renderQueue
	{
		[NativeName("SetCustomRenderQueue")]
		 set { } //Length: 68
	}

	public Shader shader
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public String[] shaderKeywords
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public Material(Shader shader) { }

	[RequiredByNativeCode]
	public Material(Material source) { }

	[EditorBrowsable(EditorBrowsableState::Never (1))]
	[Obsolete("Creating materials from shader source string is no longer supported. Use Shader assets instead.", False)]
	public Material(string contents) { }

	public int ComputeCRC() { }

	[FreeFunction("MaterialScripting::CopyPropertiesFrom", HasExplicitThis = True)]
	public void CopyPropertiesFromMaterial(Material mat) { }

	[FreeFunction("MaterialScripting::CreateWithMaterial")]
	private static void CreateWithMaterial(Material self, Material source) { }

	[FreeFunction("MaterialScripting::CreateWithShader")]
	private static void CreateWithShader(Material self, Shader shader) { }

	[FreeFunction("MaterialScripting::CreateWithString")]
	private static void CreateWithString(Material self) { }

	public void DisableKeyword(string keyword) { }

	public void EnableKeyword(string keyword) { }

	public Color get_color() { }

	public Texture get_mainTexture() { }

	public Vector2 get_mainTextureOffset() { }

	[NativeName("GetShader()->GetPassCount")]
	public int get_passCount() { }

	public Shader get_shader() { }

	public String[] get_shaderKeywords() { }

	public Color GetColor(int nameID) { }

	public Color GetColor(string name) { }

	[NativeName("GetColorFromScript")]
	private Color GetColorImpl(int name) { }

	private void GetColorImpl_Injected(int name, out Color ret) { }

	[NativeName("GetFirstPropertyNameIdByAttributeFromScript")]
	private int GetFirstPropertyNameIdByAttribute(ShaderPropertyFlags attributeFlag) { }

	public float GetFloat(string name) { }

	public float GetFloat(int nameID) { }

	[NativeName("GetFloatFromScript")]
	private float GetFloatImpl(int name) { }

	[FreeFunction("MaterialScripting::GetShaderKeywords", HasExplicitThis = True)]
	private String[] GetShaderKeywords() { }

	public string GetTag(string tag, bool searchFallbacks) { }

	[NativeName("GetTag")]
	private string GetTagImpl(string tag, bool currentSubShaderOnly, string defaultValue) { }

	public Texture GetTexture(string name) { }

	public Texture GetTexture(int nameID) { }

	[NativeName("GetTextureFromScript")]
	private Texture GetTextureImpl(int name) { }

	public Vector2 GetTextureOffset(string name) { }

	public Vector2 GetTextureOffset(int nameID) { }

	public Vector2 GetTextureScale(int nameID) { }

	[NativeName("GetTextureScaleAndOffsetFromScript")]
	private Vector4 GetTextureScaleAndOffsetImpl(int name) { }

	private void GetTextureScaleAndOffsetImpl_Injected(int name, out Vector4 ret) { }

	public Vector4 GetVector(int nameID) { }

	[NativeName("HasPropertyFromScript")]
	public bool HasProperty(int nameID) { }

	public bool HasProperty(string name) { }

	public void set_color(Color value) { }

	public void set_enableInstancing(bool value) { }

	public void set_mainTexture(Texture value) { }

	public void set_mainTextureOffset(Vector2 value) { }

	[NativeName("SetCustomRenderQueue")]
	public void set_renderQueue(int value) { }

	public void set_shader(Shader value) { }

	public void set_shaderKeywords(String[] value) { }

	public void SetColor(int nameID, Color value) { }

	public void SetColor(string name, Color value) { }

	[NativeName("SetColorFromScript")]
	private void SetColorImpl(int name, Color value) { }

	private void SetColorImpl_Injected(int name, ref Color value) { }

	public void SetFloat(int nameID, float value) { }

	public void SetFloat(string name, float value) { }

	[NativeName("SetFloatFromScript")]
	private void SetFloatImpl(int name, float value) { }

	public void SetInt(string name, int value) { }

	public void SetMatrix(int nameID, Matrix4x4 value) { }

	[NativeName("SetMatrixFromScript")]
	private void SetMatrixImpl(int name, Matrix4x4 value) { }

	private void SetMatrixImpl_Injected(int name, ref Matrix4x4 value) { }

	[FreeFunction("MaterialScripting::SetPass", HasExplicitThis = True)]
	public bool SetPass(int pass) { }

	[FreeFunction("MaterialScripting::SetShaderKeywords", HasExplicitThis = True)]
	private void SetShaderKeywords(String[] names) { }

	public void SetTexture(string name, Texture value) { }

	public void SetTexture(int nameID, Texture value) { }

	[NativeName("SetTextureFromScript")]
	private void SetTextureImpl(int name, Texture value) { }

	public void SetTextureOffset(int nameID, Vector2 value) { }

	public void SetTextureOffset(string name, Vector2 value) { }

	[NativeName("SetTextureOffsetFromScript")]
	private void SetTextureOffsetImpl(int name, Vector2 offset) { }

	private void SetTextureOffsetImpl_Injected(int name, ref Vector2 offset) { }

	public void SetTextureScale(int nameID, Vector2 value) { }

	[NativeName("SetTextureScaleFromScript")]
	private void SetTextureScaleImpl(int name, Vector2 scale) { }

	private void SetTextureScaleImpl_Injected(int name, ref Vector2 scale) { }

	public void SetVector(int nameID, Vector4 value) { }

	public void SetVector(string name, Vector4 value) { }

}

