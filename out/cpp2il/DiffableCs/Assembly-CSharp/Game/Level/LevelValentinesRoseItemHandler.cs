namespace Game.Level;

public class LevelValentinesRoseItemHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject, ILevelSpawnDuringGameplay
{
	[SerializeField]
	private int _originalNumberOfPetals; //Field offset: 0x20
	[SerializeField]
	private int _numberOfPetals; //Field offset: 0x24
	[SerializeField]
	private string _soundName; //Field offset: 0x28
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x30
	[SerializeField]
	private Sprite[] _roseStates; //Field offset: 0x38
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x40
	[SerializeField]
	private LevelSpawner _levelSpawner; //Field offset: 0x48
	[SerializeField]
	private LevelSpawn[] _petalToSpawnFrom; //Field offset: 0x50
	[SerializeField]
	private LevelCAValentinesRoseItemHandler _caHandler; //Field offset: 0x58
	[SerializeField]
	private LevelCharacter _levelCharacter; //Field offset: 0x60
	public bool ShouldPlaySadAnimationNext; //Field offset: 0x68
	public bool HasSetDataFromCA; //Field offset: 0x69
	public bool ShouldStopAnimations; //Field offset: 0x6A

	public int NumberOfPetals
	{
		 get { } //Length: 8
	}

	public LevelValentinesRoseItemHandler() { }

	public void AddASinglePetal() { }

	private void Awake() { }

	private void EnsureOnReadyPostLoad() { }

	public int get_NumberOfPetals() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void InitPetals() { }

	private void OnCARemovedFromCharacter(LevelCAHandlerBase handler, ICATarget target) { }

	private void OnDestroy() { }

	private void OnHolderBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void OnHolderEndDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void OnLevelPostInit() { }

	private void OnPlacedOnAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	public override void OnSpawnDuringGameplay() { }

	public void PluckPetal() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void UpdateSpriteOnPlucking() { }

}

