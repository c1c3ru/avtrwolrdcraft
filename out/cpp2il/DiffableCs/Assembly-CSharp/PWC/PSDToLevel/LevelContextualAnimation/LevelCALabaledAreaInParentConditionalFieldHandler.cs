namespace PWC.PSDToLevel.LevelContextualAnimation;

public class LevelCALabaledAreaInParentConditionalFieldHandler : LevelCAConditionalFieldHandlerBase
{
	[SerializeField]
	private string _label; //Field offset: 0x20

	public LevelCALabaledAreaInParentConditionalFieldHandler() { }

	public virtual bool IsConditionMet(ICATarget target) { }

}

