namespace Store.Level;

public class LevelStorePackSpawnLocation : MonoBehaviour
{
	public static readonly Dictionary<StorePackType, LevelStorePackSpawnLocation> Current; //Field offset: 0x0
	[SerializeField]
	private StorePackType _storePackType; //Field offset: 0x20

	private static LevelStorePackSpawnLocation() { }

	public LevelStorePackSpawnLocation() { }

	private void Awake() { }

	public Vector2 GetSpawnPosition() { }

	public StorePackType GetStorePackType() { }

	private void OnDestroy() { }

	private void OnPostInit() { }

	private void UpdateNotificationPopupIfNeeded() { }

}

