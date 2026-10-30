namespace UnityEngine;

[NativeClass("TextRenderingPrivate::TextMesh")]
[NativeHeader("Modules/TextRendering/Public/TextMesh.h")]
[RequireComponent(typeof(Transform), typeof(MeshRenderer))]
public sealed class TextMesh : Component
{

	public Color color
	{
		 get { } //Length: 88
		 set { } //Length: 84
	}

	public string text
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public TextMesh() { }

	public Color get_color() { }

	private void get_color_Injected(out Color ret) { }

	public string get_text() { }

	public void set_color(Color value) { }

	private void set_color_Injected(ref Color value) { }

	public void set_text(string value) { }

}

