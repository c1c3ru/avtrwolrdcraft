namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerFireFighterSpineSkinHandler : LevelCASpineSkinHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCAToddlerFireFighterSpineSkinHandler() { }

	public virtual bool CanTargetHoldItems() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

}

