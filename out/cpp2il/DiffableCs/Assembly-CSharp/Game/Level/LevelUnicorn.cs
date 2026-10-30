namespace Game.Level;

[AddComponentMenu(null)]
public class LevelUnicorn : LevelSimpleSpawnerItem
{
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x368

	public LevelUnicorn() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

}

