namespace PWC.Level;

public interface ILevelConsumer
{

	public ILevelEntity GetEntity() { }

	public GameShape GetGameShape() { }

	public SortingElement GetSortingElement() { }

	public int GetSortPriority() { }

	public Transform GetTransform() { }

	public bool TryLevelItemDropInteraction(LevelItem levelItem, out MPEventIdentifierData mpData) { }

}

