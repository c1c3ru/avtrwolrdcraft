namespace PWC.Level;

public class LevelInstancedLevelSwitcher : LevelLevelSwitcher
{
	[SerializeField]
	private PDPrefab _owner; //Field offset: 0x48

	public LevelInstancedLevelSwitcher() { }

	public virtual bool CanTravel() { }

	protected virtual string GetArrivalBulkDataKey() { }

	protected virtual string GetDestinationBulkDataKey() { }

	public virtual void LoadScene() { }

	protected virtual bool TryClaimArrival() { }

	private bool TryGetDestination(out string sceneName, out string ownerSceneGuid, out string sceneId) { }

	private bool TryGetOwnerSceneGuid(out string ownerSceneGuid) { }

}

