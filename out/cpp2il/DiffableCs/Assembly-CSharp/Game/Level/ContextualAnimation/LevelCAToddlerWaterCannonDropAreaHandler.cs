namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerWaterCannonDropAreaHandler : LevelCAWaterCannonDropAreaHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB8

	public LevelCAToddlerWaterCannonDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected virtual void GetCurrentPlayAnimationName(LevelCAConfig config) { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

}

