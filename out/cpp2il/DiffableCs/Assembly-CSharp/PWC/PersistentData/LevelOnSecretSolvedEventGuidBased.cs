namespace PWC.PersistentData;

public class LevelOnSecretSolvedEventGuidBased : LevelOnSecretSolvedEvent
{

	public LevelOnSecretSolvedEventGuidBased() { }

	protected virtual bool CheckIsSolvedBaseOnData(string secretData) { }

}

