namespace PWC.Level;

public class LevelUseColorHandlerSpawnerHandler : MonoBehaviour
{
	[SerializeField]
	private LevelSimpleSpawnerBase _spawner; //Field offset: 0x20
	[SerializeField]
	private LevelEffectColorHandler _colorHandler; //Field offset: 0x28

	public LevelUseColorHandlerSpawnerHandler() { }

	public void SpawnWithColor() { }

}

