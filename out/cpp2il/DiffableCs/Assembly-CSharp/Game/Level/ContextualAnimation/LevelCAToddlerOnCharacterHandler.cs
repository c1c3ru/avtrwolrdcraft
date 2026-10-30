namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerOnCharacterHandler : LevelCAToddlerOnCharacterHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCAToddlerOnCharacterHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected virtual string GetBoneName() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

