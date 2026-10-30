namespace Flat3D;

[ExecuteAlways]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class Flat3DPlane : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Vector3, Vector2> <>9__27_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal Vector2 <Apply>b__27_0(Vector3 x) { }

	}

	[Header("Name")]
	[SerializeField]
	private string _name; //Field offset: 0x20
	[FormerlySerializedAs("_size")]
	[Header("Transform")]
	public Vector2 size; //Field offset: 0x28
	[FormerlySerializedAs("_rotation")]
	public Vector3 rotation; //Field offset: 0x30
	[FormerlySerializedAs("_scale2D")]
	public Vector2 scale2D; //Field offset: 0x3C
	[FormerlySerializedAs("_offset")]
	public Vector2 offset; //Field offset: 0x44
	public Vector2 offset2D; //Field offset: 0x4C
	[FormerlySerializedAs("_pivot")]
	[Header("Pivot")]
	public Vector2 pivot; //Field offset: 0x54
	[FormerlySerializedAs("_cameraDistance")]
	[Header("Camera")]
	public float cameraDistance; //Field offset: 0x5C
	public bool useOrthographicCamera; //Field offset: 0x60
	[FormerlySerializedAs("_texture")]
	[Header("Texture")]
	public Texture2D texture; //Field offset: 0x68
	[FormerlySerializedAs("_textureScale")]
	public Vector2 textureScale; //Field offset: 0x70
	[FormerlySerializedAs("_textureOffset")]
	public Vector2 textureOffset; //Field offset: 0x78
	[FormerlySerializedAs("_textureBondPatternOffset")]
	public float textureBondPatternOffset; //Field offset: 0x80
	[FormerlySerializedAs("_textureHeightXOffset")]
	public float textureHeightXOffset; //Field offset: 0x84
	[FormerlySerializedAs("_updatePolygonCollider")]
	[Header("Collider")]
	public bool updatePolygonCollider; //Field offset: 0x88
	[HideInInspector]
	[SerializeField]
	private Vector3[] _points; //Field offset: 0x90
	[HideInInspector]
	[SerializeField]
	private List<Vector3> _uv; //Field offset: 0x98
	[HideInInspector]
	[SerializeField]
	private Vector3[] _vertices; //Field offset: 0xA0
	private Mesh _mesh; //Field offset: 0xA8
	private MeshRenderer _meshRenderer; //Field offset: 0xB0
	private Nullable<Vector2> _lastPivot; //Field offset: 0xB8

	public string Name
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public Flat3DPlane() { }

	public void Apply(bool updateTexture = false, bool updatePoints = false, bool updateUV = false, bool updateMaterialProperties = false) { }

	private void CreateNewMesh() { }

	public void FixTextureScaleX() { }

	public void FixTextureScaleY() { }

	public string get_Name() { }

	private Vector2 GetGoodScaleRatio() { }

	public void set_Name(string value) { }

}

