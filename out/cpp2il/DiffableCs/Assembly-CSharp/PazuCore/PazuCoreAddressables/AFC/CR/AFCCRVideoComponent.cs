namespace PazuCore.PazuCoreAddressables.AFC.CR;

public class AFCCRVideoComponent : AFCVideoComponentBase
{
	[SerializeField]
	private string _cloudResponseKey; //Field offset: 0x68
	[SerializeField]
	private String[] _path; //Field offset: 0x70

	public AFCCRVideoComponent() { }

	public virtual void LoadVideo() { }

	private void LoadVideoFromCloudRequest() { }

}

