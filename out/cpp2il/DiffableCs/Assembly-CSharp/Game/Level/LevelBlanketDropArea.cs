namespace Game.Level;

public class LevelBlanketDropArea : LevelSingleItemDropArea
{
	[SerializeField]
	private LevelDropArea[] _babyAndToddlerDropAreas; //Field offset: 0xD8

	public LevelBlanketDropArea() { }

	protected virtual void Awake() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	protected virtual void OnDestroy() { }

	public virtual void OnItemEndDrop(LevelItem levelItem) { }

	public virtual void OnItemPickUp(LevelItem levelItem) { }

	private void RemoveBlanket(LevelItem levelItem) { }

}

