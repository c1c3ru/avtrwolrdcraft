namespace PWC.Level;

public class LevelRuntimeColoredMeshHandler : LevelRuntimeColoredRendererHandlerBase, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private MeshRenderer _meshRenderer; //Field offset: 0x40

	public LevelRuntimeColoredMeshHandler() { }

	public virtual void SetColor(Color color, PWSpriteColorType colorType = 1, bool ensureShader = true) { }

}

