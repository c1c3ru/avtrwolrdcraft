namespace PWC.Level;

public class LevelToggleableAudioRecordPlayerListenerHandler : MonoBehaviour
{
	[SerializeField]
	private LevelMusicRecordPlayerHandler _musicRecordPlayer; //Field offset: 0x20
	[SerializeField]
	private string _emptySound; //Field offset: 0x28
	private LevelToggleableAudio _toggleableAudio; //Field offset: 0x30

	public LevelToggleableAudioRecordPlayerListenerHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnRecordChanged(LevelMusicRecord musicRecord) { }

}

