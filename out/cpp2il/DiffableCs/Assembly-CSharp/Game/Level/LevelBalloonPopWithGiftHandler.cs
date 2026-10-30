namespace Game.Level;

public class LevelBalloonPopWithGiftHandler : LevelBalloonPopHandler
{
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x58
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x60
	[SerializeField]
	private PDPrefabReference _giftOnPop; //Field offset: 0x68
	[SerializeField]
	private string _prizeSoundName; //Field offset: 0x70
	public int _hasDroppedTheGift; //Field offset: 0x78

	public LevelBalloonPopWithGiftHandler() { }

	protected virtual void DestroyBalloon() { }

	private void DropGiftIfNeeded() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	private LevelSpawn GetPrefabToSpawn(PDPrefabReference _reference) { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

