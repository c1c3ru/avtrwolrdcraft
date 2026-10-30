namespace Game.Level;

public class LevelOnVinylEnterMusicRecordPlayerHandler : MonoBehaviour
{
	[SerializeField]
	private string _label; //Field offset: 0x20
	[SerializeField]
	private UnityEvent OnCorrectRecordEntered; //Field offset: 0x28
	[SerializeField]
	private UnityEvent OnCorrectRecordRemoved; //Field offset: 0x30
	[SerializeField]
	private UnityEvent OnWrongRecordEntered; //Field offset: 0x38
	[SerializeField]
	private UnityEvent OnWrongRecordRemoved; //Field offset: 0x40
	private LevelMusicRecordPlayerHandler _musicRecordPlayer; //Field offset: 0x48
	private LevelMusicRecord _musicRecord; //Field offset: 0x50
	private bool _isCorrectRecord; //Field offset: 0x58

	public LevelOnVinylEnterMusicRecordPlayerHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	public void OnRecordChanged(LevelMusicRecord musicRecord) { }

	public void RecordRemoved() { }

}

