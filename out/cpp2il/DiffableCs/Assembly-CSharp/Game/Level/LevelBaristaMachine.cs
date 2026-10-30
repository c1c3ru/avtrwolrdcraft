namespace Game.Level;

public class LevelBaristaMachine : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass40_0
	{
		public LevelBaristaMachine <>4__this; //Field offset: 0x10
		public int index; //Field offset: 0x18
		public LevelCharacter barista; //Field offset: 0x20

		public <>c__DisplayClass40_0() { }

		internal void <CreateCoffee>b__0(MPDataGeneratorHandle _) { }

	}

	internal class LevelBaristaMachinePD
	{
		public int value; //Field offset: 0x10
		public bool isDoorOpen; //Field offset: 0x14

		public LevelBaristaMachinePD() { }

	}

	[SerializeField]
	private LevelSingleItemDropArea _baristaDropArea; //Field offset: 0x20
	[SerializeField]
	private LevelDropArea _finishedDropArea; //Field offset: 0x28
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x30
	[SerializeField]
	private PDPrefabReference[] _drinks; //Field offset: 0x38
	[SerializeField]
	private PDPrefabReference[] _saucers; //Field offset: 0x40
	[SerializeField]
	private Color[] _drinkColors; //Field offset: 0x48
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x50
	[SerializeField]
	private GameSoundPlayer _gameSoundPlayer; //Field offset: 0x58
	[SerializeField]
	private string _workingSoundName; //Field offset: 0x60
	[SerializeField]
	private string _buttonsSoundName; //Field offset: 0x68
	[SerializeField]
	private string _openLidSoundName; //Field offset: 0x70
	[SerializeField]
	private string _closeLidSoundName; //Field offset: 0x78
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x80
	[SerializeField]
	private int _maxNumOfDrinksPerFill; //Field offset: 0x88
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private String[] _idleAnimationsNames; //Field offset: 0x90
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private string _workingAnimationName; //Field offset: 0x98
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private String[] _dynamicAnimationsNames; //Field offset: 0xA0
	[SerializeField]
	private LevelCoffeeContainer _levelCoffeeContainer; //Field offset: 0xA8
	[SerializeField]
	private string _skinFolder; //Field offset: 0xB0
	private Animation _workingAnimation; //Field offset: 0xB8
	private Animation _idleCloseAnimation; //Field offset: 0xC0
	private Animation _idleOpenAnimation; //Field offset: 0xC8
	private Animation _closeAnimation; //Field offset: 0xD0
	private Animation _openAnimation; //Field offset: 0xD8
	private int _numOfUses; //Field offset: 0xE0
	private bool _isDoorOpen; //Field offset: 0xE4
	private bool _isWorking; //Field offset: 0xE5
	private Skin _skin; //Field offset: 0xE8
	private Skin[] _pressedButtonsSkins; //Field offset: 0xF0
	private Skin[] _notPressedButtonsSkins; //Field offset: 0xF8

	public bool IsDoorOpen
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public LevelBaristaMachine() { }

	private void Awake() { }

	public void CreateCoffee(int index, LevelCharacter barista) { }

	public void CreateCoffeeWithoutBarista(int index) { }

	private void FindAllSkins() { }

	public bool get_IsDoorOpen() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private LevelSpawn GetPrefabDrinkToSpawn(int index) { }

	private LevelSpawn GetPrefabSaucerToSpawn(int index) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void RefreshSkeletonAnimation() { }

	private void RemoveSkin(Skin skin) { }

	public void set_IsDoorOpen(bool value) { }

	public void SetFull() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

