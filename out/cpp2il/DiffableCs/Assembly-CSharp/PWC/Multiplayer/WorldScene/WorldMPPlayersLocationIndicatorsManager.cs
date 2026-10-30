namespace PWC.Multiplayer.WorldScene;

public class WorldMPPlayersLocationIndicatorsManager : MonoBehaviour
{
	private readonly List<WorldMPUIPlayerLocationIndicator> _indicators; //Field offset: 0x20

	public WorldMPPlayersLocationIndicatorsManager() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnPlayerChangedScene(int uid, string sceneName) { }

	private void SyncView() { }

}

