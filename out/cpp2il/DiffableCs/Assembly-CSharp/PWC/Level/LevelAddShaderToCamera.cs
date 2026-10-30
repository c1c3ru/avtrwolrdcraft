namespace PWC.Level;

public class LevelAddShaderToCamera : MonoBehaviour
{
	[SerializeField]
	private Shader _shader; //Field offset: 0x20
	private Material _material; //Field offset: 0x28

	public LevelAddShaderToCamera() { }

	private void Awake() { }

	private void OnRenderImage(RenderTexture source, RenderTexture destination) { }

}

