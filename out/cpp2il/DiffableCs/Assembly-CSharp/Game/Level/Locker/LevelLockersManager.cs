namespace Game.Level.Locker;

public class LevelLockersManager : MonoBehaviour
{
	[SerializeField]
	private LevelLockerSpawnOnPostInit[] _lockers; //Field offset: 0x20
	[SerializeField]
	private int _minFullLockers; //Field offset: 0x28
	private readonly List<PDPrefabReference> _items; //Field offset: 0x30
	private String[] _clothes; //Field offset: 0x38

	public LevelLockersManager() { }

	private void Awake() { }

	private void InitLists() { }

	private void InitLockers() { }

	private void OnDestroy() { }

}

