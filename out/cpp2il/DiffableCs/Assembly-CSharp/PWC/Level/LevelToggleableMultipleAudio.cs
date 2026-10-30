namespace PWC.Level;

public class LevelToggleableMultipleAudio : LevelToggleableAudio
{
	[SerializeField]
	private String[] _soundNames; //Field offset: 0xA0
	[SerializeField]
	private Sprite[] _onSprites; //Field offset: 0xA8
	protected int _currentIndex; //Field offset: 0xB0

	public LevelToggleableMultipleAudio() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	public void RemotePlaySoundByIndex(int index) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public virtual void ToggleState() { }

}

