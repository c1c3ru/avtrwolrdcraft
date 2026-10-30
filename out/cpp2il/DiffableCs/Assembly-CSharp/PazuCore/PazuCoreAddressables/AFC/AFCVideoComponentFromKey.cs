namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCVideoComponentFromKey : AFCVideoComponentBase
{
	[SerializeField]
	private string _videoKey; //Field offset: 0x68

	public AFCVideoComponentFromKey() { }

	public virtual void LoadVideo() { }

	private void LoadVideoFromURL() { }

}

