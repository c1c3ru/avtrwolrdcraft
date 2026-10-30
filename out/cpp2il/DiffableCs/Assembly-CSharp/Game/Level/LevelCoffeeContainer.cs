namespace Game.Level;

public class LevelCoffeeContainer : LevelConsumerAreaBase, IHasPersistentData, IRequirePDSceneObject, ILevelSpawnDuringGameplay
{
	[SerializeField]
	private SpriteRenderer _renderer; //Field offset: 0x58
	[SerializeField]
	private Sprite _filled; //Field offset: 0x60
	[SerializeField]
	private LevelBaristaMachine _baristaMachine; //Field offset: 0x68
	[SerializeField]
	private int _capacity; //Field offset: 0x70
	[SerializeField]
	private int _startAmount; //Field offset: 0x74
	public UnityEvent onFillAction; //Field offset: 0x78
	public UnityEvent onEmptyAction; //Field offset: 0x80
	[CompilerGenerated]
	private bool <IsFull>k__BackingField; //Field offset: 0x88
	private int _currentAmount; //Field offset: 0x8C

	public bool IsFull
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public LevelCoffeeContainer() { }

	protected virtual void Awake() { }

	public void DecreaseAmount() { }

	public void Empty() { }

	private void EnsureOnReadyPostLoad() { }

	public void Fill() { }

	[CompilerGenerated]
	public bool get_IsFull() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void OnSpawnDuringGameplay() { }

	[CompilerGenerated]
	public void set_IsFull(bool value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void UpdateSpriteEmpty() { }

	public void UpdateSpriteFull() { }

}

