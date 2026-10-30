namespace Game.Level;

[AddComponentMenu(null)]
public class LevelHandheldConsole : LevelItem
{
	[SerializeField]
	private GameObject _screen; //Field offset: 0x348

	public LevelHandheldConsole() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

}

