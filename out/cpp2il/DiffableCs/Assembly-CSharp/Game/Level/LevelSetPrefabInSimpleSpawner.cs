namespace Game.Level;

public class LevelSetPrefabInSimpleSpawner : MonoBehaviour
{
	[SerializeField]
	private LevelSimpleSpawner _spawner; //Field offset: 0x20
	[SerializeField]
	private PDPrefabReference[] _prefabReferences; //Field offset: 0x28
	private int _prefabCount; //Field offset: 0x30

	public LevelSetPrefabInSimpleSpawner() { }

	public void SetNextPrefab() { }

	public void SetPrefabByIndex(int index) { }

}

