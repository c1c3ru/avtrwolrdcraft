namespace Game.Level.ContextualAnimation;

public class LevelCAWeightHeightMeasureDropAreaHandler : LevelCADropAreaHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x80

	public LevelCAWeightHeightMeasureDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

}

