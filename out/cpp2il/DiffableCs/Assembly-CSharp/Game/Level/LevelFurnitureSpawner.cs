namespace Game.Level;

public class LevelFurnitureSpawner : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, IMultiplayer_Messageable, IMultiplayer_NetworkIdentityBase
{
	private const string SOLD_ONE_SIGN = "Sold_Out_Sign_L47"; //Field offset: 0x0
	private const string LAST_ONE_SIGN = "Last_One_Sticker_L47"; //Field offset: 0x0
	private const string FURNITURE_SPAWNER = "FurnitureSpawner_"; //Field offset: 0x0
	[SerializeField]
	private PDSceneObject _pdSceneObject; //Field offset: 0x20
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x28
	[SerializeField]
	protected LevelSpawner _spawner; //Field offset: 0x30
	[SerializeField]
	private int _maxNumberOfSpawnedFurnitures; //Field offset: 0x38
	[SerializeField]
	private SpriteRenderer _stockSpriteRenderer; //Field offset: 0x40
	[SerializeField]
	private SpriteRenderer _lastItemSign; //Field offset: 0x48
	[SerializeField]
	private SpriteRenderer _soldOutSign; //Field offset: 0x50
	[SerializeField]
	private string _soundName; //Field offset: 0x58
	[SerializeField]
	protected PDPrefabReference _boxPrefabReference; //Field offset: 0x60
	[SerializeField]
	protected string _furnitureTypeIndex; //Field offset: 0x68
	[SerializeField]
	protected PDPrefabReference _furnitruePrefabReference; //Field offset: 0x70
	[SerializeField]
	private float _spawnDelayTime; //Field offset: 0x78
	private bool _isSoldOut; //Field offset: 0x7C
	private int _numberOfSpawnedFurnitures; //Field offset: 0x80
	private CShape _cShape; //Field offset: 0x88
	[CompilerGenerated]
	private int <Multiplayer_ComponentIndex>k__BackingField; //Field offset: 0x90

	public override int Multiplayer_ComponentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public SpriteRenderer StockSpriteRenderer
	{
		 get { } //Length: 8
	}

	public LevelFurnitureSpawner() { }

	[CompilerGenerated]
	private void <TrySpawnFromBeginDrag>b__30_0() { }

	private void Awake() { }

	[CompilerGenerated]
	public override int get_Multiplayer_ComponentIndex() { }

	public SpriteRenderer get_StockSpriteRenderer() { }

	private string GetPDSceneObjectGuid() { }

	private LevelSpawn GetPrefabToSpawn() { }

	private string GlobalSpawnerGUID() { }

	public override void OnBeginDrag(PointerEventData eventData) { }

	private void OnDestroy() { }

	public override void OnDrag(PointerEventData eventData) { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	private void OnPrePostInit() { }

	public void OnSpawnRemoved() { }

	private override void PWC.Multiplayer.IMultiplayer_Messageable.Multiplayer_ReceiveMessage(MPEventIdentifierData idData, object objectData) { }

	[CompilerGenerated]
	public override void set_Multiplayer_ComponentIndex(int value) { }

	private void SetLastItemSign(bool isLastItem) { }

	private void SetSoldOut(bool isSoldOut) { }

	private bool TrySpawnFromBeginDrag(out LevelSpawn newInstance) { }

	private void UpdateQuantitySigns() { }

}

