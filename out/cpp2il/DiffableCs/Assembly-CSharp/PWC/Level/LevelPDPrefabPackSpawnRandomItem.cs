namespace PWC.Level;

public class LevelPDPrefabPackSpawnRandomItem : MonoBehaviour, IPDPrefabPackSpawn
{
	[SerializeField]
	private PDPrefabReference[] _prefabs; //Field offset: 0x20

	public LevelPDPrefabPackSpawnRandomItem() { }

	public override void OnSpawnFromPDPrefabPack() { }

}

