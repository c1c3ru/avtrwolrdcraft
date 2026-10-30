namespace Game.Level;

public class LevelToaster : LevelItem
{
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x348

	public LevelToaster() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

}

