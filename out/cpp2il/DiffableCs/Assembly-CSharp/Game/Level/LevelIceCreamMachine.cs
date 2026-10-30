namespace Game.Level;

public class LevelIceCreamMachine : LevelStationaryItem, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private LevelSingleItemDropArea _coneDropArea; //Field offset: 0x60
	[SerializeField]
	private LevelIceCreamSpawner _spawner; //Field offset: 0x68
	[SerializeField]
	private List<Color> _iceCreamColors; //Field offset: 0x70

	public LevelIceCreamMachine() { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

