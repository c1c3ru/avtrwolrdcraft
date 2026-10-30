namespace PWC.Level;

public abstract class LevelRuntimeColoredRendererHandlerBase : MonoBehaviour, ILevelColorable
{
	[SerializeField]
	private LevelEffectColorHandler _effectColorHandler; //Field offset: 0x20
	protected PWSpriteColorType _colorType; //Field offset: 0x28
	protected Color _color; //Field offset: 0x2C
	[CompilerGenerated]
	private bool <HasPersistentData>k__BackingField; //Field offset: 0x3C

	public bool HasPersistentData
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	protected LevelRuntimeColoredRendererHandlerBase() { }

	[CompilerGenerated]
	public bool get_HasPersistentData() { }

	public override Color GetColor() { }

	protected override string GetPDKeyOverride() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	[CompilerGenerated]
	protected void set_HasPersistentData(bool value) { }

	public override void SetColor(Color color, PWSpriteColorType colorType = 1, bool ensureShader = true) { }

	public override void SetMultiplyColor(Color color) { }

	public override void SetOverlayColor(Color color) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

