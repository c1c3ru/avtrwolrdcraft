namespace PWC.Level.Maker.Customization;

public class LevelMakerCustomizationMeshRenderer : LevelMakerCustomizationHandlerBase, ILevelMakerUIMenuItem
{
	private static readonly int _ColorID; //Field offset: 0x0
	private static readonly int _MainTexID; //Field offset: 0x4
	[SerializeField]
	private MeshRenderer _meshRenderer; //Field offset: 0x58
	private Material _material; //Field offset: 0x60
	private bool _didInitMaterial; //Field offset: 0x68

	private static LevelMakerCustomizationMeshRenderer() { }

	public LevelMakerCustomizationMeshRenderer() { }

	protected virtual void Awake() { }

	public void Init() { }

	private void InitMaterialIfNeeded() { }

	private override void PWC.Level.Maker.ILevelMakerUIMenuItem.OnCreatedInsideUIItem() { }

	protected virtual void SetColorInternal(Color color) { }

	protected virtual void SetTextureInternal(Texture2D texture) { }

}

