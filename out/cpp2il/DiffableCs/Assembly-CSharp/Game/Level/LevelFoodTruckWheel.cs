namespace Game.Level;

public class LevelFoodTruckWheel : LevelPumpableItemHandler
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x60
	[SerializeField]
	private Sprite _blownSprite; //Field offset: 0x68
	private int _pumpCounter; //Field offset: 0x70

	public LevelFoodTruckWheel() { }

	public virtual void OnPumped() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

