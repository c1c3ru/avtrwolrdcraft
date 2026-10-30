namespace PWC.Multiplayer.WorldScene;

public class WorldMPUIPlayersCountViewer : MonoBehaviour
{
	[SerializeField]
	private Text _text; //Field offset: 0x20
	[SerializeField]
	private Text _outOfText; //Field offset: 0x28

	public WorldMPUIPlayersCountViewer() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnPlayerJoined(int playerUID) { }

	private void OnPlayerRemoved(int playerUID) { }

	private void SyncView() { }

}

