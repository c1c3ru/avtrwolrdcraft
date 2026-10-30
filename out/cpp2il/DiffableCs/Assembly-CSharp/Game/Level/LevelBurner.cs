namespace Game.Level;

public class LevelBurner : LevelItem
{
	[SerializeField]
	private LevelFryArea _fryArea; //Field offset: 0x348

	public LevelBurner() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

}

