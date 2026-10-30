namespace Game.Level;

public class LevelLockedSpineDoor : LevelSpineDoor
{
	private bool _isUnlocked; //Field offset: 0xD0

	public LevelLockedSpineDoor() { }

	protected virtual void Awake() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnDestroy() { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

	private void SetInitialAnimation() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void UnlockDoor() { }

}

