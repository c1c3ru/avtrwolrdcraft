namespace UnityEngine;

[NativeHeader("Runtime/Camera/Light.h")]
[NativeHeader("Runtime/Export/Graphics/Light.bindings.h")]
[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Transform))]
public sealed class Light : Behaviour
{
	private int m_BakedIndex; //Field offset: 0x18

	public LightBakingOutput bakingOutput
	{
		 get { } //Length: 104
	}

	public float bounceIntensity
	{
		 get { } //Length: 60
	}

	public Color color
	{
		 get { } //Length: 88
		 set { } //Length: 84
	}

	public float colorTemperature
	{
		 get { } //Length: 60
	}

	public Texture cookie
	{
		 get { } //Length: 60
	}

	public float cookieSize
	{
		 get { } //Length: 60
	}

	public float intensity
	{
		 get { } //Length: 60
	}

	public float range
	{
		 get { } //Length: 60
	}

	public LightShadows shadows
	{
		[NativeMethod("GetShadowType")]
		 get { } //Length: 60
	}

	public float spotAngle
	{
		 get { } //Length: 60
	}

	[NativeProperty("LightType")]
	public LightType type
	{
		 get { } //Length: 60
	}

	public bool useColorTemperature
	{
		 get { } //Length: 60
	}

	public LightBakingOutput get_bakingOutput() { }

	private void get_bakingOutput_Injected(out LightBakingOutput ret) { }

	public float get_bounceIntensity() { }

	public Color get_color() { }

	private void get_color_Injected(out Color ret) { }

	public float get_colorTemperature() { }

	public Texture get_cookie() { }

	public float get_cookieSize() { }

	public float get_intensity() { }

	public float get_range() { }

	[NativeMethod("GetShadowType")]
	public LightShadows get_shadows() { }

	public float get_spotAngle() { }

	public LightType get_type() { }

	public bool get_useColorTemperature() { }

	public void set_color(Color value) { }

	private void set_color_Injected(ref Color value) { }

}

