namespace PWC.Multiplayer.WorldScene;

public class WorldMPUIConnectionTypeViewer : MonoBehaviour
{
	[SerializeField]
	private GameObject _hostState; //Field offset: 0x20
	[SerializeField]
	private GameObject _clientState; //Field offset: 0x28

	public WorldMPUIConnectionTypeViewer() { }

	private void Awake() { }

}

