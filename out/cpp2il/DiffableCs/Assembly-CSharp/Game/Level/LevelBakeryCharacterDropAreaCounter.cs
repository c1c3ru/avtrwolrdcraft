namespace Game.Level;

public class LevelBakeryCharacterDropAreaCounter : LevelCharactersOnlyDropArea
{
	[SerializeField]
	private List<UnityEventOnCounter> _onCharacterDropEvents; //Field offset: 0xE0
	private int _characersDropCount; //Field offset: 0xE8

	public LevelBakeryCharacterDropAreaCounter() { }

	public virtual void OnItemEndDrop(LevelItem levelItem) { }

}

