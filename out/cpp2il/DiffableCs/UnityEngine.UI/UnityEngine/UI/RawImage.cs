namespace UnityEngine.UI;

[AddComponentMenu("UI/Raw Image", 12)]
[RequireComponent(typeof(CanvasRenderer))]
public class RawImage : MaskableGraphic
{
	[FormerlySerializedAs("m_Tex")]
	[SerializeField]
	private Texture m_Texture; //Field offset: 0xD8
	[SerializeField]
	private Rect m_UVRect; //Field offset: 0xE0

	public virtual Texture mainTexture
	{
		 get { } //Length: 344
	}

	public Texture texture
	{
		 get { } //Length: 8
		 set { } //Length: 188
	}

	public Rect uvRect
	{
		 get { } //Length: 12
		 set { } //Length: 76
	}

	protected RawImage() { }

	public virtual Texture get_mainTexture() { }

	public Texture get_texture() { }

	public Rect get_uvRect() { }

	protected virtual void OnDidApplyAnimationProperties() { }

	protected virtual void OnPopulateMesh(VertexHelper vh) { }

	public void set_texture(Texture value) { }

	public void set_uvRect(Rect value) { }

	public virtual void SetNativeSize() { }

}

