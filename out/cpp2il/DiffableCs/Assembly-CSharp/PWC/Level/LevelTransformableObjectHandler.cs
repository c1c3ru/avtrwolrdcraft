namespace PWC.Level;

public class LevelTransformableObjectHandler : LevelTransformableObjectHandlerBase, ILevelMakerDisabledWhileInEditMode, ILevelMakerUICountExtraPrefab
{
	[SerializeField]
	protected PDPrefabReference _prefabReference; //Field offset: 0x80

	public LevelTransformableObjectHandler() { }

	protected virtual bool CanBeClicked() { }

	protected virtual void DestroySelf() { }

	protected virtual int GetSortingOrder() { }

	public virtual string GetTransformTargetPrefabName() { }

	private override string PWC.Level.ILevelMakerUICountExtraPrefab.GetExtraPrefabGuid() { }

	protected virtual bool TrySpawnImplement(out PDPrefab pdPrefabInstance) { }

}

