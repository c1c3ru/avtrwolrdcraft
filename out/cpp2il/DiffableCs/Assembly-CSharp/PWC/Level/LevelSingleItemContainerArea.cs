namespace PWC.Level;

public class LevelSingleItemContainerArea : LevelContainerArea
{

	public LevelSingleItemContainerArea() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	public virtual float GetXPositionOnDropArea(float fromXPosition, LevelItem levelItem, Nullable<Single> optionalYPosition = null) { }

}

