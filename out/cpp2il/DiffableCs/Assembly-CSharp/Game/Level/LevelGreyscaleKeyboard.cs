namespace Game.Level;

public class LevelGreyscaleKeyboard : LevelItem
{
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x348
	private bool _isOn; //Field offset: 0x350

	public LevelGreyscaleKeyboard() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SyncState() { }

}

