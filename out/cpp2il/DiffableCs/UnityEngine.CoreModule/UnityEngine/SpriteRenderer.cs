namespace UnityEngine;

[NativeType("Runtime/Graphics/Mesh/SpriteRenderer.h")]
[RequireComponent(typeof(Transform))]
public sealed class SpriteRenderer : Renderer
{
	private UnityEvent<SpriteRenderer> m_SpriteChangeEvent; //Field offset: 0x18

	public Color color
	{
		 get { } //Length: 88
		 set { } //Length: 84
	}

	public bool flipX
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public SpriteMaskInteraction maskInteraction
	{
		 set { } //Length: 68
	}

	public Vector2 size
	{
		 get { } //Length: 76
		 set { } //Length: 72
	}

	public Sprite sprite
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public SpriteSortPoint spriteSortPoint
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public SpriteRenderer() { }

	public Color get_color() { }

	private void get_color_Injected(out Color ret) { }

	public bool get_flipX() { }

	public Vector2 get_size() { }

	private void get_size_Injected(out Vector2 ret) { }

	public Sprite get_sprite() { }

	public SpriteSortPoint get_spriteSortPoint() { }

	[RequiredByNativeCode]
	private void InvokeSpriteChanged() { }

	public void set_color(Color value) { }

	private void set_color_Injected(ref Color value) { }

	public void set_flipX(bool value) { }

	public void set_maskInteraction(SpriteMaskInteraction value) { }

	public void set_size(Vector2 value) { }

	private void set_size_Injected(ref Vector2 value) { }

	public void set_sprite(Sprite value) { }

	public void set_spriteSortPoint(SpriteSortPoint value) { }

}

