namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCVideoComponentForScreen : AFCVideoComponentBase
{
	[SerializeField]
	private string _tableUrl; //Field offset: 0x68
	[SerializeField]
	private string _longUrl; //Field offset: 0x70
	[SerializeField]
	private string _veryLongUrl; //Field offset: 0x78

	public AFCVideoComponentForScreen() { }

	public virtual void LoadVideo() { }

	private void LoadVideoFromURL() { }

}

