namespace PWC.Level;

public class LevelItemPreventPutInToddlerHand : LevelItemDropConditionBase
{

	public LevelItemPreventPutInToddlerHand() { }

	protected virtual void CanBeDroppedOn(LevelDropArea dropArea, ref bool canDrop) { }

}

