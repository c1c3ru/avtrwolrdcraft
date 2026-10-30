namespace PWC.Level.Maker.CustomizationConfig;

public class LevelMakerCCTiles : LevelMakerCCWithFolderBase
{
	public List<String> tiles; //Field offset: 0x28
	private List<String> _paths; //Field offset: 0x30

	public LevelMakerCCTiles() { }

	public IList<String> GetPaths() { }

	public IList<Texture2D> GetTextures() { }

}

