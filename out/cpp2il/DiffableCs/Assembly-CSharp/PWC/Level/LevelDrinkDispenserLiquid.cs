namespace PWC.Level;

public class LevelDrinkDispenserLiquid : LevelConsumerAreaBase
{
	[SerializeField]
	private Color _color; //Field offset: 0x54
	[SerializeField]
	private List<LevelFillableHandler> _staticFillables; //Field offset: 0x68

	public Color Color
	{
		 get { } //Length: 12
	}

	public LevelDrinkDispenserLiquid() { }

	public Color get_Color() { }

	protected virtual void OnEnable() { }

	public void SetColor(Color color) { }

	private void TryFillAvailableHandlers() { }

}

