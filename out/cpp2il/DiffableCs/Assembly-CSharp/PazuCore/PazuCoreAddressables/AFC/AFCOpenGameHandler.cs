namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCOpenGameHandler : MonoBehaviour
{
	[SerializeField]
	private int _gameId; //Field offset: 0x20
	[SerializeField]
	private string _context; //Field offset: 0x28

	public AFCOpenGameHandler() { }

	public void OpenGame() { }

}

