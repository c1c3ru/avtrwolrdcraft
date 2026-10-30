namespace PWC.Level;

[AddComponentMenu(null)]
public class LevelJugLiquid : LevelDrinkFillerOnDragItemHandler
{
	[SerializeField]
	private LevelDrinkableWithFillItemHandler _myHandler; //Field offset: 0xC0
	[SerializeField]
	private LevelJugContainer _jugContainer; //Field offset: 0xC8
	private int _pourIndex; //Field offset: 0xD0

	public LevelJugLiquid() { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

}

