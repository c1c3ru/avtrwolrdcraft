namespace PWC.UGC;

public class UGCPresetHolder : MonoBehaviour, IUGCSpawnableFromUI, IHasPDTextBulkData
{
	[SerializeField]
	private PDTextBulkData _pdTextBulkData; //Field offset: 0x20

	public UGCPresetHolder() { }

	private void EnsureSceneGuids(GameObject instance, IUGCGridItemOwner owner) { }

	private override PDTextBulkData PWC.PersistentData.IHasPDTextBulkData.GetPDTextBulkData() { }

	public void SyncPresetDataEntranceLevelType(PDSceneObject sceneObject) { }

	public bool TrySpawnOnOwner(IUGCGridItemOwner owner, out IUGCEntity outInstance, bool isPlayable = true) { }

}

