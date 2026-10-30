namespace Game.Level.ContextualAnimation;

public class LevelCAWaterCannonDropAreaHandler : LevelCAWaterCannonDropAreaHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB8

	public LevelCAWaterCannonDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual SpineType GetSpineType() { }

}

