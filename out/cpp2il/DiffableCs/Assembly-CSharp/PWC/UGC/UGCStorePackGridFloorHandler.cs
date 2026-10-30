namespace PWC.UGC;

public class UGCStorePackGridFloorHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	internal class UGCStorePackGridFloorHandlerPD
	{
		public bool didSpawnPreset; //Field offset: 0x10
		public bool didCameraFocusOnGift; //Field offset: 0x11

		public UGCStorePackGridFloorHandlerPD() { }

	}

	public static StorePackType StorePackToOpen; //Field offset: 0x0
	[SerializeField]
	private StorePackType _storePackType; //Field offset: 0x20
	[SerializeField]
	private InventoryFlagType _inventoryFlagType; //Field offset: 0x24
	[SerializeField]
	private PDPrefabReference _presetPDPrefabReference; //Field offset: 0x28
	private UGCGridFloor _gridFloor; //Field offset: 0x30
	private bool _didSpawnPreset; //Field offset: 0x38
	private bool _didCameraFocusOnGift; //Field offset: 0x39

	public UGCStorePackGridFloorHandler() { }

	private void Awake() { }

	public Vector2 GetCetnerPosition() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public bool IsAvailableForUser() { }

	public void OnClaimWhileInScene() { }

	private void OnDestroy() { }

	private void OnUGCPostInit() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SpawnPresetIfNeeded() { }

}

