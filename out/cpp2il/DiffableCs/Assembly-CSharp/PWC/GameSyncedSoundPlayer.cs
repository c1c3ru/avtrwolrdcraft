namespace PWC;

public class GameSyncedSoundPlayer : GameSoundPlayer
{
	public static readonly Dictionary<String, List`1<GameSyncedSoundPlayer>> All; //Field offset: 0x0
	[SerializeField]
	private string _linkId; //Field offset: 0x40

	private static GameSyncedSoundPlayer() { }

	public GameSyncedSoundPlayer() { }

	private void AddSoundPlayer(string linkId) { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	protected virtual void OnPlay() { }

	private void RemoveSoundPlayer(string linkId) { }

	public void SetLinkID(string value) { }

}

