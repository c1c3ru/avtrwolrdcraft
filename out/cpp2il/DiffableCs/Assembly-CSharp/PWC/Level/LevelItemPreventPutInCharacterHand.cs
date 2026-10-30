namespace PWC.Level;

public class LevelItemPreventPutInCharacterHand : LevelItemDropConditionBase
{

	public LevelItemPreventPutInCharacterHand() { }

	protected virtual void CanPutInCharacterHand(LevelCharacter character, ref bool canDrop) { }

}

