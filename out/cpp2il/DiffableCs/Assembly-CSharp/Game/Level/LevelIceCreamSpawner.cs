namespace Game.Level;

public class LevelIceCreamSpawner : LevelSimpleSpawner
{
	[SerializeField]
	private LevelDropArea _noConeDropArea; //Field offset: 0x98
	private Color _currentIceCreamColor; //Field offset: 0xA0
	private Color _currentIceCreamMultiColor; //Field offset: 0xB0
	private LevelDropArea _currentConeDropArea; //Field offset: 0xC0

	public LevelIceCreamSpawner() { }

	protected virtual void OnPostSpawn(LevelItem levelItem) { }

	public void SetConeDropArea(LevelDropArea currentConeDropArea) { }

	public void SetIceCreamColor(Color color) { }

	public void SetIceCreamMultiColor(Color color) { }

}

