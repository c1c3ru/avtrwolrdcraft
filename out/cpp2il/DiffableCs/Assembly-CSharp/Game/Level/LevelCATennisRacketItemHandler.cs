namespace Game.Level;

public class LevelCATennisRacketItemHandler : LevelCAItemHandlerBase
{

	public LevelCATennisRacketItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

}

