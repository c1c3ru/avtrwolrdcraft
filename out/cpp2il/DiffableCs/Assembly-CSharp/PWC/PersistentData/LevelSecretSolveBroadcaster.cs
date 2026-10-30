namespace PWC.PersistentData;

public class LevelSecretSolveBroadcaster : MonoBehaviour
{
	[SerializeField]
	private SecretFullId _secret; //Field offset: 0x20
	[SerializeField]
	private string _extraData; //Field offset: 0x28
	[SerializeField]
	private PDSceneObject _sceneObject; //Field offset: 0x30

	public LevelSecretSolveBroadcaster() { }

	public void BroadcastSolvedSecret() { }

	public void BroadcastSolvedSecret(string extraData) { }

	public void BroadcastSolvedSecret(string extraData, int secretID) { }

	public void BroadcastSolvedSecretBasedOnGuid() { }

	public void RemoveSolvedSecret() { }

}

