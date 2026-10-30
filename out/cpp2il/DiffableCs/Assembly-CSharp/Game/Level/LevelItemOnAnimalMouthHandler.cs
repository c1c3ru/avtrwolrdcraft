namespace Game.Level;

public class LevelItemOnAnimalMouthHandler : LevelItemOnAvatarMouthHandlerBase
{

	public LevelItemOnAnimalMouthHandler() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnReadyPostLoad() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

