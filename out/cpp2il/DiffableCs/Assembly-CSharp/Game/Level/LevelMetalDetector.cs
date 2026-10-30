namespace Game.Level;

public class LevelMetalDetector : LevelActionOnItemEnter
{

	public LevelMetalDetector() { }

	protected virtual void OnItemEnter(LevelItem levelItem) { }

	protected virtual void OnItemExit(LevelItem levelItem, ExitReasonType exitReasonType) { }

}

