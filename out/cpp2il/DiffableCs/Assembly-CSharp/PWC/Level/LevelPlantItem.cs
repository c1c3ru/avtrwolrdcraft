namespace PWC.Level;

public class LevelPlantItem : LevelItem
{
	[SerializeField]
	protected Sprite[] _plantSprites; //Field offset: 0x348
	protected int _plantIndex; //Field offset: 0x350

	public LevelPlantItem() { }

	public bool DidGrowComplete() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetPlantIndex(int index) { }

	public override void TryIncrementPlant() { }

}

