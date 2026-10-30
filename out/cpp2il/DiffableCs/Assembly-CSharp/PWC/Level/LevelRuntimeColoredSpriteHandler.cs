namespace PWC.Level;

public class LevelRuntimeColoredSpriteHandler : LevelRuntimeColoredRendererHandlerBase, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x40

	public LevelRuntimeColoredSpriteHandler() { }

	protected virtual string GetPDKeyOverride() { }

	public virtual void SetColor(Color color, PWSpriteColorType colorType = 1, bool ensureShader = true) { }

}

