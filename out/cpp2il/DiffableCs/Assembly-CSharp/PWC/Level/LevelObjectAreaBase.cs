namespace PWC.Level;

public abstract class LevelObjectAreaBase : LevelAreaBase
{
	[SerializeField]
	protected int _itemAreaLayer; //Field offset: 0x38

	public int MyItemAreaLayer
	{
		 get { } //Length: 8
	}

	protected LevelObjectAreaBase() { }

	public int get_MyItemAreaLayer() { }

}

