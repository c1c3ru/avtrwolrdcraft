namespace PWC.Level;

[AddComponentMenu(null)]
public class LevelJugDropArea : LevelSingleItemFoodOnlyDropArea
{
	[SerializeField]
	private LevelJugDrinkable _jugDrinkable; //Field offset: 0xE0
	private LevelCanBeDroppedInAJugItemHandler _droppedItem; //Field offset: 0xE8

	public LevelJugDropArea() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	public virtual void OnItemEndDrop(LevelItem levelItem) { }

	public virtual void OnItemPickUp(LevelItem levelItem) { }

}

