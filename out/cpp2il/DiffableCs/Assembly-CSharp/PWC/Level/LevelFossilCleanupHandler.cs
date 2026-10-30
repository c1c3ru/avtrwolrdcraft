namespace PWC.Level;

[DisallowMultipleComponent]
[RequireComponent(typeof(LevelItem))]
public class LevelFossilCleanupHandler : LevelTransformableItemHandlerBase
{
	[SerializeField]
	protected PDPrefabReference _prefabReference; //Field offset: 0x88

	public LevelFossilCleanupHandler() { }

	protected virtual bool CanBeClicked() { }

	public virtual string GetTransformTargetPrefabName() { }

	public void SpawnCleanFossil(LevelCharacter levelCharacter) { }

	protected virtual bool TrySpawnImplement(out PDPrefab pdPrefabInstance) { }

}

