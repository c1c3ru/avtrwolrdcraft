namespace PWC.Level.Maker.Customization;

public class LevelMakerCustomizationFlat3DPlane : LevelMakerCustomizationHandlerBase
{
	private static readonly int _ColorID; //Field offset: 0x0
	private static readonly int _MainTexID; //Field offset: 0x4
	[SerializeField]
	private Flat3DPlane _flat3DPlane; //Field offset: 0x58
	private Material _material; //Field offset: 0x60
	private Vector2 _defaultTextureScale; //Field offset: 0x68

	private static LevelMakerCustomizationFlat3DPlane() { }

	public LevelMakerCustomizationFlat3DPlane() { }

	protected virtual void Awake() { }

	protected virtual void SetColorInternal(Color color) { }

	protected virtual void SetTextureInternal(Texture2D texture) { }

}

