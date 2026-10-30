namespace PWC;

public class MeshSpreader : MonoBehaviour
{
	[SerializeField]
	private Vector2 _size; //Field offset: 0x20
	[SerializeField]
	private float _angle; //Field offset: 0x28
	[SerializeField]
	private Vector2 _uvTiling; //Field offset: 0x2C
	[SerializeField]
	private Vector2 _uvOffset; //Field offset: 0x34
	[SerializeField]
	private Vector2 _pivot; //Field offset: 0x3C

	public MeshSpreader() { }

	public static Mesh CreateGridMesh(int width, int height, Vector2 uvTiling, Vector2 uvOffset, Vector2 quadSize, Vector2 pivot) { }

	private void OnValidate() { }

	[ContextMenu("Spread")]
	private void Spread() { }

}

