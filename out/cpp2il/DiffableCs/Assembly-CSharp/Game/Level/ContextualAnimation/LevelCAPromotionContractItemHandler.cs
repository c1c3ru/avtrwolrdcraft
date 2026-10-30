namespace Game.Level.ContextualAnimation;

public class LevelCAPromotionContractItemHandler : LevelCAItemHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCAPromotionContractItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

