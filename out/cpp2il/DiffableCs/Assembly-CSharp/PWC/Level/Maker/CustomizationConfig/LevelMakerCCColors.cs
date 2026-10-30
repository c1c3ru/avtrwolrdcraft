namespace PWC.Level.Maker.CustomizationConfig;

public class LevelMakerCCColors : LevelMakerCCBase
{
	public List<String> colors; //Field offset: 0x20
	private Color[] _parsedColors; //Field offset: 0x28

	public LevelMakerCCColors() { }

	public Color[] GetParsedColors() { }

}

