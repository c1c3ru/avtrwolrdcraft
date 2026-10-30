namespace Game.Level;

[AddComponentMenu(null)]
public class LevelGachaponMachineToy : LevelItem
{
	private string _spritePath; //Field offset: 0x348

	public LevelGachaponMachineToy() { }

	private void GetAndSetSprite() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	public virtual void OnSpawnDuringGameplay() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

