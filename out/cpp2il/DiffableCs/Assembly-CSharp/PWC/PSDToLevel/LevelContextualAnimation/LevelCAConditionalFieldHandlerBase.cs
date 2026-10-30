namespace PWC.PSDToLevel.LevelContextualAnimation;

public abstract class LevelCAConditionalFieldHandlerBase : MonoBehaviour
{

	protected LevelCAConditionalFieldHandlerBase() { }

	public abstract bool IsConditionMet(ICATarget target) { }

}

