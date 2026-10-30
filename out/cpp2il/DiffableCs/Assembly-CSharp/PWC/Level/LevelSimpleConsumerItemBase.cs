namespace PWC.Level;

public abstract class LevelSimpleConsumerItemBase : LevelItem, ILevelConsumer
{

	protected LevelSimpleConsumerItemBase() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	private override ILevelEntity PWC.Level.ILevelConsumer.GetEntity() { }

	private override GameShape PWC.Level.ILevelConsumer.GetGameShape() { }

	private override int PWC.Level.ILevelConsumer.GetSortPriority() { }

	private override Transform PWC.Level.ILevelConsumer.GetTransform() { }

	public override bool TryLevelItemDropInteraction(LevelItem levelItem, out MPEventIdentifierData mpData) { }

}

