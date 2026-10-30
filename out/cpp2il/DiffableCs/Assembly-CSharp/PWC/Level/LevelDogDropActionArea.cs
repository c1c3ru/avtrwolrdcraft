namespace PWC.Level;

public class LevelDogDropActionArea : LevelPairInteractionAreaBase
{

	public LevelDogDropActionArea() { }

	protected virtual bool TryGetCAHandlerForType(Type pairType, out Type caHandlerType) { }

}

