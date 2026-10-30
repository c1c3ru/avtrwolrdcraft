//Type is in global namespace

[ExecuteInEditMode]
[RequireComponent(typeof(CanvasRenderer))]
[RequireComponent(typeof(ParticleSystem))]
public class UIParticleSystem : MaskableGraphic
{
	public Texture particleTexture; //Field offset: 0xD8
	public Sprite particleSprite; //Field offset: 0xE0
	private Transform _transform; //Field offset: 0xE8
	private ParticleSystem _particleSystem; //Field offset: 0xF0
	private Particle[] _particles; //Field offset: 0xF8
	private UIVertex[] _quad; //Field offset: 0x100
	private Vector4 _uv; //Field offset: 0x108
	private TextureSheetAnimationModule _textureSheetAnimation; //Field offset: 0x118
	private int _textureSheetAnimationFrames; //Field offset: 0x120
	private Vector2 _textureSheedAnimationFrameSize; //Field offset: 0x124
	private List<Vector4> customData; //Field offset: 0x130

	public virtual Texture mainTexture
	{
		 get { } //Length: 180
	}

	public UIParticleSystem() { }

	protected virtual void Awake() { }

	public virtual Texture get_mainTexture() { }

	protected bool Initialize() { }

	protected virtual void OnPopulateMesh(VertexHelper vh) { }

	private void Update() { }

}

