namespace PWC.Level;

public class LevelNonCharacterBlockedArea : LevelBlockedArea
{

	public LevelNonCharacterBlockedArea() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

}

