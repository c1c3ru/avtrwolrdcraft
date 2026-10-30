namespace Game.Level.ContextualAnimation;

public class LevelCANotBouncingBasketBallItemHandler : LevelCAItemHandlerBase
{

	public LevelCANotBouncingBasketBallItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

