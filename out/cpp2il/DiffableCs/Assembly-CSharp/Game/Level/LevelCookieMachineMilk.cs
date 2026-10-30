namespace Game.Level;

public class LevelCookieMachineMilk : LevelStationaryItem, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelDrinkDispenserLiquid _drinkDispenserLiquid; //Field offset: 0x60
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x68
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x70
	private bool _isOn; //Field offset: 0x78

	public LevelCookieMachineMilk() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SyncState() { }

}

