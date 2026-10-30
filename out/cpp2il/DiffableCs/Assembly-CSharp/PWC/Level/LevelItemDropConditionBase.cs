namespace PWC.Level;

public abstract class LevelItemDropConditionBase : MonoBehaviour
{
	private LevelItem _levelItem; //Field offset: 0x20

	protected LevelItemDropConditionBase() { }

	protected override void Awake() { }

	protected override void CanBeDroppedOn(LevelDropArea dropArea, ref bool canDrop) { }

	protected override void CanPutInCharacterHand(LevelCharacter character, ref bool canDrop) { }

	protected override void OnDestroy() { }

}

