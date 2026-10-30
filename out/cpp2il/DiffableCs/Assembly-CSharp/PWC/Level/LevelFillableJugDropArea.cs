namespace PWC.Level;

public class LevelFillableJugDropArea : LevelSingleItemFoodOnlyDropArea
{
	[SerializeField]
	private GameObject _fillableGameObject; //Field offset: 0xE0
	private LevelCanBeDroppedInAJugItemHandler _droppedItem; //Field offset: 0xE8
	private ILevelFillable _fillable; //Field offset: 0xF0

	public LevelFillableJugDropArea() { }

	protected virtual void Awake() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	public virtual void OnItemEndDrop(LevelItem levelItem) { }

	public virtual void OnItemPickUp(LevelItem levelItem) { }

}

