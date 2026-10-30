namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCTextureComponent : AFCTextureComponentBase
{
	[SerializeField]
	private string _key; //Field offset: 0x60

	public AFCTextureComponent() { }

	public virtual void LoadTexture() { }

	private void LoadTextureFromURL() { }

}

