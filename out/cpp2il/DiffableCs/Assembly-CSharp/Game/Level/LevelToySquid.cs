namespace Game.Level;

[AddComponentMenu(null)]
public class LevelToySquid : LevelSimpleToggleableItem
{
	private bool _isHappy; //Field offset: 0x36C

	public LevelToySquid() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	protected virtual void PlaySound() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

