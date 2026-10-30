namespace Game.Level.ContextualAnimation;

public class LevelCAOrigamiBirdItemHandler : LevelCAItemWithSkinHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB0

	public LevelCAOrigamiBirdItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	protected virtual string GetSkinName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

