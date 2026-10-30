namespace Game.Level;

public class MeshData
{
	public Vector3[] vertices; //Field offset: 0x10
	public Vector3[] normals; //Field offset: 0x18
	public Int32[] triangles; //Field offset: 0x20

	public MeshData(Mesh mesh) { }

	public Mesh ToMesh() { }

}

