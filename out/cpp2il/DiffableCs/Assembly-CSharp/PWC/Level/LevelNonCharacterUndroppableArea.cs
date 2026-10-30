namespace PWC.Level;

public class LevelNonCharacterUndroppableArea : LevelUndroppableArea
{

	public LevelNonCharacterUndroppableArea() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

}

