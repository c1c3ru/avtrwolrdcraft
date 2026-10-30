namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerTamagotchiItemHandler : LevelCAHandHeldDeviceItemHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAToddlerTamagotchiItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

