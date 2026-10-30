namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCTextureComponentFromLibrary : AFCTextureComponentBase
{
	private enum TextureType
	{
		CoverPhoto = 0,
		Round = 1,
		Regular = 2,
		Icon = 3,
	}

	[SerializeField]
	private int _gameId; //Field offset: 0x60
	[SerializeField]
	private TextureType _textureType; //Field offset: 0x64

	public AFCTextureComponentFromLibrary() { }

	private void LoadGameUrlFromLibrary(int gameId) { }

	public virtual void LoadTexture() { }

}

