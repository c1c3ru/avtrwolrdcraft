namespace PWC.Level;

public class LevelRuntimeColoredSpineHandler : LevelRuntimeColoredRendererHandlerBase, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x40
	private bool _didEnsureMaterials; //Field offset: 0x48

	public LevelRuntimeColoredSpineHandler() { }

	private void EnsureMaterials() { }

	protected virtual string GetPDKeyOverride() { }

	public virtual void SetColor(Color color, PWSpriteColorType colorType = 1, bool ensureShader = true) { }

}

