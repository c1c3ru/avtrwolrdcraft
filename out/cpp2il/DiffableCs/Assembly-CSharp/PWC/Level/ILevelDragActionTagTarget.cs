namespace PWC.Level;

public interface ILevelDragActionTagTarget : ILevelConsumer
{

	public void OnEnter(LevelDragActionByTagItemHandler handler) { }

	public void OnExit(LevelDragActionByTagItemHandler handler) { }

}

