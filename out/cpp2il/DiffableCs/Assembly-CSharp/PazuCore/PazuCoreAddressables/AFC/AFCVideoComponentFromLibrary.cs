namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCVideoComponentFromLibrary : AFCVideoComponentBase
{
	[SerializeField]
	private int _gameId; //Field offset: 0x64

	public AFCVideoComponentFromLibrary() { }

	private void LoadGameUrlFromLibrary(int gameId) { }

	public virtual void LoadVideo() { }

}

