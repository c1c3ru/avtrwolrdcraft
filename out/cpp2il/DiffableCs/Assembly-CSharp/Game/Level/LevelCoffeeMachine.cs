namespace Game.Level;

public class LevelCoffeeMachine : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass22_0
	{
		public LevelCoffeeMachine <>4__this; //Field offset: 0x10
		public LevelCoffeeMachineCoffeeCupItemHandler coffeeCup; //Field offset: 0x18

		public <>c__DisplayClass22_0() { }

		internal void <OnDrinkClick>g__OnCupEndLand|0(LevelDropArea dropArea) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public LevelCoffeeMachine <>4__this; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18

		public <>c__DisplayClass23_0() { }

		internal void <FillCup>b__0() { }

	}

	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x20
	[SerializeField]
	private LevelSingleItemDropArea _cupDropArea; //Field offset: 0x28
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x30
	[SerializeField]
	private SpriteRenderer _coffeeType; //Field offset: 0x38
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x40
	[SerializeField]
	private LevelSpawn[] _prefab; //Field offset: 0x48
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x50
	[SerializeField]
	private List<Sprite> _coffeeTypeSprites; //Field offset: 0x58
	[SerializeField]
	private List<Color> _coffeeColors; //Field offset: 0x60
	[SerializeField]
	private bool _poofEffect; //Field offset: 0x68
	[SerializeField]
	private string _soundName; //Field offset: 0x70
	[SerializeField]
	private int NUMBER_OF_DRINK_TYPES; //Field offset: 0x78
	private int _drinkTypeCounter; //Field offset: 0x7C
	private Color _coffeeColor; //Field offset: 0x80

	public LevelCoffeeMachine() { }

	private void Awake() { }

	private void FillCup(ILevelFillable fillableItem, LevelItem levelItem) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnArrowClick() { }

	public void OnArrowCounterDecrease() { }

	public void OnArrowCounterIncrease() { }

	private void OnDestroy() { }

	public void OnDrinkClick() { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void ParticleSystemSetActive(bool value) { }

	private void SetCoffeType() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

