namespace PWC.Level;

public class LevelInstancedLevelExitSwitcher : LevelLevelSwitcher
{

	public LevelInstancedLevelExitSwitcher() { }

	public virtual bool CanTravel() { }

	protected virtual string GetArrivalBulkDataKey() { }

	protected virtual string GetDestinationBulkDataKey() { }

	public virtual void LoadScene() { }

	protected virtual bool TryClaimArrival() { }

}

