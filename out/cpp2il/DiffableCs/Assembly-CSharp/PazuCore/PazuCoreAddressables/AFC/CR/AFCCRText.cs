namespace PazuCore.PazuCoreAddressables.AFC.CR;

public class AFCCRText : AFCUnityMessageDrivenHandlerBase
{
	[SerializeField]
	private Text _text; //Field offset: 0x28
	[SerializeField]
	private string _cloudResponseKey; //Field offset: 0x30
	[SerializeField]
	private String[] _path; //Field offset: 0x38

	public AFCCRText() { }

	public virtual void PerformAction() { }

	public void SetText() { }

}

