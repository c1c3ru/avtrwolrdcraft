namespace PWC.Level;

public class LevelCharacterDropActionArea : LevelPairInteractionAreaBase
{

	public LevelCharacterDropActionArea() { }

	protected virtual bool TryGetCAHandlerForType(Type pairType, out Type caHandlerType) { }

}

