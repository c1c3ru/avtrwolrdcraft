namespace PWC.Level;

public class LevelMultiToggleableAudio : LevelToggleableAudio
{
	[SerializeField]
	protected List<String> _soundsNames; //Field offset: 0xA0
	private int _soundIndex; //Field offset: 0xA8

	public LevelMultiToggleableAudio() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SyncSpeakers() { }

	public virtual void ToggleState() { }

}

