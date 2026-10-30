namespace TMPro;

public struct TMP_MeshInfo
{
	private static readonly Color32 s_DefaultColor; //Field offset: 0x0
	private static readonly Vector3 s_DefaultNormal; //Field offset: 0x4
	private static readonly Vector4 s_DefaultTangent; //Field offset: 0x10
	private static readonly Bounds s_DefaultBounds; //Field offset: 0x20
	public Mesh mesh; //Field offset: 0x0
	public int vertexCount; //Field offset: 0x8
	public Vector3[] vertices; //Field offset: 0x10
	public Vector3[] normals; //Field offset: 0x18
	public Vector4[] tangents; //Field offset: 0x20
	public Vector2[] uvs0; //Field offset: 0x28
	public Vector2[] uvs2; //Field offset: 0x30
	public Color32[] colors32; //Field offset: 0x38
	public Int32[] triangles; //Field offset: 0x40
	public Material material; //Field offset: 0x48

	private static TMP_MeshInfo() { }

	public TMP_MeshInfo(Mesh mesh, int size) { }

	public TMP_MeshInfo(Mesh mesh, int size, bool isVolumetric) { }

	public void Clear() { }

	public void Clear(bool uploadChanges) { }

	public void ClearUnusedVertices() { }

	public void ClearUnusedVertices(int startIndex) { }

	public void ClearUnusedVertices(int startIndex, bool updateMesh) { }

	public void ResizeMeshInfo(int size) { }

	public void ResizeMeshInfo(int size, bool isVolumetric) { }

	public void SortGeometry(VertexSortingOrder order) { }

	public void SortGeometry(IList<Int32> sortingOrder) { }

	public void SwapVertexData(int src, int dst) { }

}

