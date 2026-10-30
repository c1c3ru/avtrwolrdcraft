namespace Game.Level;

public class LevelBushAnimalHidingSpot : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public LevelBushAnimalHidingSpot <>4__this; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18

		public <>c__DisplayClass18_0() { }

		internal void <OnSecretSolved>b__0(TrackEntry x) { }

	}

	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x28
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x30
	[SerializeField]
	private PDPrefabReference _animalPrefabReference; //Field offset: 0x38
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x40
	[SerializeField]
	private Transform _spawnTarget; //Field offset: 0x48
	[SerializeField]
	private string _requiredItemName; //Field offset: 0x50
	[SerializeField]
	private string _exitAnimationName; //Field offset: 0x58
	[SerializeField]
	private UnityEvent onSpawnedAnimalAction; //Field offset: 0x60
	[SerializeField]
	private int _avatarID; //Field offset: 0x68
	private bool _hasFoundTheCat; //Field offset: 0x6C
	private bool _hasRevealedTheCat; //Field offset: 0x6D
	private LevelAnimal _spawnedAnimal; //Field offset: 0x70
	private bool _attemptToSpawnCat; //Field offset: 0x78

	public LevelBushAnimalHidingSpot() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	public void OnPinterClick() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public void OnSecretSolved() { }

	private void OnSecretSolved(LevelItem levelItem) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

