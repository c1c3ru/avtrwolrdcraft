namespace PWC.Level;

public abstract class LevelSimpleDragActionCharacterAreaBase : LevelSimpleDragActionItemBase, ILevelDragActionCharacterAreaItemHandler, ILevelDragActionItemHandler
{

	protected LevelSimpleDragActionCharacterAreaBase() { }

	public abstract AreaType GetAreaTypeToCheck() { }

	public virtual bool TryDragInteraction(ILevelConsumer consumer) { }

}

