namespace Game.Level;

public class LevelFireworksBox : LevelItem
{
	[SerializeField]
	private LevelSingleItemDropArea _leftFireworksArea; //Field offset: 0x348
	[SerializeField]
	private LevelSingleItemDropArea _rightFireworksArea; //Field offset: 0x350
	[SerializeField]
	private PDPrefabReference _leftFirework; //Field offset: 0x358
	[SerializeField]
	private PDPrefabReference _rightFirework; //Field offset: 0x360

	public LevelFireworksBox() { }

	protected virtual void OnLevelPostInit() { }

}

