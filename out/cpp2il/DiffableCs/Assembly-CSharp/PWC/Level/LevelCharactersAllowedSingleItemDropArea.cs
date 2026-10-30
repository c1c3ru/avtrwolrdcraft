namespace PWC.Level;

[AddComponentMenu(null)]
public class LevelCharactersAllowedSingleItemDropArea : LevelSingleItemDropArea
{

	public LevelCharactersAllowedSingleItemDropArea() { }

	public virtual bool CanConsumeCharacters() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

}

