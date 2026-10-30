namespace PWC.Level;

[DisallowMultipleComponent]
[RequireComponent(typeof(LevelItem))]
public class LevelTransformableItemHandler : LevelTransformableItemHandlerBase, ILevelMakerUICountExtraPrefab
{
	[SerializeField]
	protected PDPrefabReference _prefabReference; //Field offset: 0x88
	[SerializeField]
	protected bool _stayOnDropArea; //Field offset: 0x90

	public LevelTransformableItemHandler() { }

	public string GetPDPRefabReferenceGuid() { }

	public virtual string GetTransformTargetPrefabName() { }

	private override string PWC.Level.ILevelMakerUICountExtraPrefab.GetExtraPrefabGuid() { }

	public void SetPDPRefabReference(PDPrefabReference pdPrefabReference) { }

	protected virtual bool TrySpawnImplement(out PDPrefab pdPrefabInstance) { }

}

