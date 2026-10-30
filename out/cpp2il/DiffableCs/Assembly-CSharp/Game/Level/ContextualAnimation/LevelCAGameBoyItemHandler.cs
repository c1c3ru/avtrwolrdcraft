namespace Game.Level.ContextualAnimation;

public class LevelCAGameBoyItemHandler : LevelCAHandHeldDeviceItemHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAGameBoyItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

