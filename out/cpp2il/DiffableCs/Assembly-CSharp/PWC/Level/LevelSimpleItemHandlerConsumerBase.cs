namespace PWC.Level;

public abstract class LevelSimpleItemHandlerConsumerBase : MonoBehaviour, ILevelConsumer
{
	protected LevelItem _levelItem; //Field offset: 0x20

	protected LevelSimpleItemHandlerConsumerBase() { }

	protected override void Awake() { }

	private LevelItem GetLevelItem() { }

	protected override void OnDisable() { }

	protected override void OnEnable() { }

	private override ILevelEntity PWC.Level.ILevelConsumer.GetEntity() { }

	private override GameShape PWC.Level.ILevelConsumer.GetGameShape() { }

	private override SortingElement PWC.Level.ILevelConsumer.GetSortingElement() { }

	private override int PWC.Level.ILevelConsumer.GetSortPriority() { }

	private override Transform PWC.Level.ILevelConsumer.GetTransform() { }

	public override bool TryLevelItemDropInteraction(LevelItem levelItem, out MPEventIdentifierData mpData) { }

}

