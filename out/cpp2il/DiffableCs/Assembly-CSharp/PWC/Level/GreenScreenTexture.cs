namespace PWC.Level;

public class GreenScreenTexture
{
	public string Label; //Field offset: 0x10
	public PDTexture2DReference TextureReference; //Field offset: 0x18
	public InventoryFlagType InventoryFlagType; //Field offset: 0x20

	public GreenScreenTexture() { }

	public bool TryGetTexture2D(out Texture2D texture2D) { }

}

