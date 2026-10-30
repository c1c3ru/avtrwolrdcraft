namespace PazuCore;

[CreateAssetMenu]
public class GameLocalizationSettings : ScriptableObject
{
	public GameLocalizationFontsSettings localizationFontsSettings; //Field offset: 0x18
	public GameLocalizationFontsTMProSettings localizationFontsTMProSettings; //Field offset: 0x20

	public GameLocalizationSettings() { }

}

