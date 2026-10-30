namespace PWC.Level.ContextualAnimation;

public abstract class LevelCAPairAnimalNearDogHandlerBase : LevelCAPairHandlerBase
{

	protected LevelCAPairAnimalNearDogHandlerBase() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsRelevantForTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	protected override void OnCompletePairItemAnimation(TrackEntry trackEntry) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	protected override void PlayPetAnimation(LevelCAConfig config) { }

}

