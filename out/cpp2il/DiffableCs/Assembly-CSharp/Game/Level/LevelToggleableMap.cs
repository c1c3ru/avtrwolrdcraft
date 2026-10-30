namespace Game.Level;

[AddComponentMenu(null)]
public class LevelToggleableMap : LevelSimpleToggleableSpineItem
{
	[SerializeField]
	private string _alternativeSoundName; //Field offset: 0x388

	public LevelToggleableMap() { }

	protected virtual void PlaySound() { }

}

