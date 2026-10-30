namespace PWC;

public class MeshSliced : MonoBehaviour, IHasSprite
{
	[SerializeField]
	private Sprite _sprite; //Field offset: 0x20
	[Range(0, 1)]
	[SerializeField]
	private float _fill; //Field offset: 0x28
	private readonly Vector3[] _vertices; //Field offset: 0x30
	private readonly Vector2[] _uv; //Field offset: 0x38
	private MeshFilter _meshFilter; //Field offset: 0x40
	private MeshRenderer _meshRenderer; //Field offset: 0x48

	public MeshSliced() { }

	private void Awake() { }

	public float GetFill() { }

	public Sprite GetSprite() { }

	private bool IsInited() { }

	public void SetFill(float fill) { }

	public void SetSprite(Sprite sprite) { }

	private void Sync() { }

}

