namespace Game.Level;

public class LevelInitAnimalStateOnPack : MonoBehaviour, IPDPrefabPackSpawn
{
	[SerializeField]
	private LevelAnimal _animal; //Field offset: 0x20
	[SerializeField]
	private bool _isSpecificAnimation; //Field offset: 0x28
	[SerializeField]
	private int _animationIndex; //Field offset: 0x2C
	private bool _didInit; //Field offset: 0x30

	public LevelInitAnimalStateOnPack() { }

	private void Awake() { }

	private void InitIfNeeded() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private override void PWC.PersistentData.IPDPrefabPackSpawn.OnSpawnFromPDPrefabPack() { }

}

