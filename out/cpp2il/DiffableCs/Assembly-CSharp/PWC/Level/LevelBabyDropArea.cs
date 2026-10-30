namespace PWC.Level;

public class LevelBabyDropArea : LevelSingleItemDropArea
{
	[SerializeField]
	private float _angle; //Field offset: 0xD8
	[SerializeField]
	private Vector2 _position; //Field offset: 0xDC

	public LevelBabyDropArea() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	public virtual void OnItemEndDrop(LevelItem levelItem) { }

	protected virtual void OnReadyPostLoad() { }

	private void SetRotationAndPosition(LevelItem levelItem) { }

}

