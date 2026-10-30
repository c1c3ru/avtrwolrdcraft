namespace PWC.Level;

public interface ILevelDragActionItemHandler
{

	public LevelDragActionHandler DragActionHandler
	{
		 get { } //Length: 0
	}

	public LevelDragActionHandler get_DragActionHandler() { }

	public bool IsConsumerGoodTarget(ILevelConsumer consumer) { }

}

