namespace Game.Level.ContextualAnimation;

public class LevelCASoccerBallItemHandler : LevelCAItemOnBoneHandlerBase
{

	public LevelCASoccerBallItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected virtual string GetBoneName() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	protected virtual Nullable<Vector2> GetPivotOnBone() { }

	public virtual int GetPriority() { }

	public virtual SpineType GetSpineType() { }

}

