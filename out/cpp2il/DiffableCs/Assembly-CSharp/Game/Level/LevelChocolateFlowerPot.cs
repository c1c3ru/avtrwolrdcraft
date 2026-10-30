namespace Game.Level;

public class LevelChocolateFlowerPot : LevelConsumerAreaBase
{
	[SerializeField]
	private SpriteRenderer _renderer; //Field offset: 0x58
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x60
	[SerializeField]
	private Sprite _earlySprouts; //Field offset: 0x68
	[SerializeField]
	private Sprite _advancedSprouts; //Field offset: 0x70
	[SerializeField]
	private PDPrefabReference _chocolateFlower; //Field offset: 0x78
	[SerializeField]
	private UnityEvent _onFlowerFullyGrownEvent; //Field offset: 0x80
	[SerializeField]
	private UnityEvent _onFlowerRemovedEvent; //Field offset: 0x88
	private int _curWateringIndex; //Field offset: 0x90
	private bool _hasFlower; //Field offset: 0x94

	public LevelChocolateFlowerPot() { }

	private LevelSpawn GetPrefabToSpawn() { }

	private void OnFlowerDrag(DragDropItemBase item, PointerEventData eventData) { }

	public void WaterPlanet() { }

}

