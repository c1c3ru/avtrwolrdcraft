namespace PWC.Level;

public class LevelStationaryPlant : LevelPlantBase
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x40
	[SerializeField]
	private Sprite[] _plantSprites; //Field offset: 0x48
	[SerializeField]
	private String[] _incrementSounds; //Field offset: 0x50
	private int _lastSavedYear; //Field offset: 0x58
	private int _lastSavedMonth; //Field offset: 0x5C
	private int _lastSavedDay; //Field offset: 0x60
	private bool _didWaterToday; //Field offset: 0x64

	public LevelStationaryPlant() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual int GetStagesCount() { }

	public virtual float PlayIncrementSound() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	protected virtual void SetPlantIndexInternal(int index, bool playSound) { }

}

