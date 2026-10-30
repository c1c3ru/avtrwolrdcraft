namespace PWC.Level;

public abstract class LevelDragActionCharacterAreaItemHandlerBase : LevelDragActionItemHandlerBase, ILevelDragActionCharacterAreaItemHandler, ILevelDragActionItemHandler
{

	protected LevelDragActionCharacterAreaItemHandlerBase() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	public abstract AreaType GetAreaTypeToCheck() { }

	protected virtual bool PerformDragCondition(ILevelConsumer consumer) { }

}

