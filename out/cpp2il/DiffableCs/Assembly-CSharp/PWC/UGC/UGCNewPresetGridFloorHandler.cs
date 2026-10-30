namespace PWC.UGC;

public class UGCNewPresetGridFloorHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	internal class UGCNewPresetGridFloorHandlerPD
	{
		public bool didSpawnPreset; //Field offset: 0x10
		public bool didCameraFocusOnGift; //Field offset: 0x11

		public UGCNewPresetGridFloorHandlerPD() { }

	}

	[SerializeField]
	protected PDPrefabReference _presetPDPrefabReference; //Field offset: 0x20
	protected UGCGridFloor _gridFloor; //Field offset: 0x28
	protected bool _didSpawnPreset; //Field offset: 0x30
	private bool _didCameraFocusOnGift; //Field offset: 0x31

	public UGCNewPresetGridFloorHandler() { }

	private void Awake() { }

	public Vector2 GetCetnerPosition() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	protected override void OnUGCPostInit() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	protected void SpawnPresetIfNeeded() { }

	public void SyncPresetDataEntranceLevelType(PDSceneObject sceneObject) { }

}

