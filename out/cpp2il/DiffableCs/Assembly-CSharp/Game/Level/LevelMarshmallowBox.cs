namespace Game.Level;

[AddComponentMenu(null)]
public class LevelMarshmallowBox : LevelSimpleSpawnerItem
{
	[SerializeField]
	private LevelSpawn _alternatePrefab; //Field offset: 0x368

	public LevelMarshmallowBox() { }

	protected virtual LevelSpawn GetPrefab() { }

}

