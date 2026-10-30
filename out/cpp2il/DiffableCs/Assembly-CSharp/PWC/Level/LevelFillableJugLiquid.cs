namespace PWC.Level;

public class LevelFillableJugLiquid : LevelDrinkFillerOnDragItemHandler
{
	[SerializeField]
	private GameObject _fillableGameObject; //Field offset: 0xC0
	[SerializeField]
	private LevelFillableJugContainer _pouringItemHandler; //Field offset: 0xC8
	private int _pourIndex; //Field offset: 0xD0

	public LevelFillableJugLiquid() { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

}

