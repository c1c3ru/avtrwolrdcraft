namespace PazuCore.PazuCoreAddressables.AFC.CR;

public class AFCCRTextureComponent : AFCTextureComponentBase
{
	[SerializeField]
	private string _cloudResponseKey; //Field offset: 0x60
	[SerializeField]
	private String[] _path; //Field offset: 0x68

	public String[] Path
	{
		 get { } //Length: 8
	}

	public AFCCRTextureComponent() { }

	public String[] get_Path() { }

	public virtual void LoadTexture() { }

	private void LoadTextureFromCloudRequest() { }

}

