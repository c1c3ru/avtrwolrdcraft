namespace Game.Level;

public class LevelMilkFillerOnDragItemHandler : LevelDrinkFillerOnDragItemHandler
{

	public LevelMilkFillerOnDragItemHandler() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	public virtual bool IsConsumerGoodTarget(ILevelConsumer consumer) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

}

