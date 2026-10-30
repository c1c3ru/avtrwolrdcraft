namespace Spine.Unity;

public struct MeshGeneratorBuffers
{
	public int vertexCount; //Field offset: 0x0
	public Vector3[] vertexBuffer; //Field offset: 0x8
	public Vector2[] uvBuffer; //Field offset: 0x10
	public Color32[] colorBuffer; //Field offset: 0x18
	public MeshGenerator meshGenerator; //Field offset: 0x20

	public Vector2[] uv2Buffer
	{
		 get { } //Length: 24
	}

	public Vector2[] uv3Buffer
	{
		 get { } //Length: 24
	}

	public Vector2[] get_uv2Buffer() { }

	public Vector2[] get_uv3Buffer() { }

}

