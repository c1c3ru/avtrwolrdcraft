namespace Game.Level.ContextualAnimation;

public class LevelCALabaledItemsHeldConditionalFieldHandler : LevelCAConditionalFieldHandlerBase
{
	[SerializeField]
	private string _labelLeftHand; //Field offset: 0x20
	[SerializeField]
	private string _labelRightHand; //Field offset: 0x28

	public LevelCALabaledItemsHeldConditionalFieldHandler() { }

	public virtual bool IsConditionMet(ICATarget target) { }

}

