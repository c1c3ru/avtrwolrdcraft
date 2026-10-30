namespace Game.Level;

[AddComponentMenu(null)]
public class LevelToggleableAnimal : LevelSimpleToggleableItem
{
	[SerializeField]
	private string _alternativeSoundName; //Field offset: 0x370

	public LevelToggleableAnimal() { }

	protected virtual void PlaySound() { }

}

