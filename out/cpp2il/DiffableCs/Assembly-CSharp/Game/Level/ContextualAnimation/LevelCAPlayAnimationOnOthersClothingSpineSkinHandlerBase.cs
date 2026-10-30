namespace Game.Level.ContextualAnimation;

public abstract class LevelCAPlayAnimationOnOthersClothingSpineSkinHandlerBase : LevelCASpineSkinHandlerBase
{
	protected float _affectedRadius; //Field offset: 0x94
	protected string _affectedAnimationName; //Field offset: 0x98
	protected bool _isAffectedAnimationLoop; //Field offset: 0xA0
	private bool _areVariablesSet; //Field offset: 0xA1

	protected LevelCAPlayAnimationOnOthersClothingSpineSkinHandlerBase() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	private void PlayAnimationOnOthers(ICATarget target) { }

	protected abstract void SetVariables() { }

}

