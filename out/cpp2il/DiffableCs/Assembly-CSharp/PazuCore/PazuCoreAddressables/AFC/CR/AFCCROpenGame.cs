namespace PazuCore.PazuCoreAddressables.AFC.CR;

public class AFCCROpenGame : MonoBehaviour
{
	[SerializeField]
	private string _cloudResponseKey; //Field offset: 0x20
	[SerializeField]
	private string _parentalGameContext; //Field offset: 0x28
	[SerializeField]
	private String[] _path; //Field offset: 0x30

	public AFCCROpenGame() { }

	public void OpenGame() { }

}

