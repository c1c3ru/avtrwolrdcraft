namespace Game.Level.ContextualAnimation;

public class LevelCAChristmasDanceMatDropAreaHandler : LevelCADropAreaHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x80

	public LevelCAChristmasDanceMatDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

}

