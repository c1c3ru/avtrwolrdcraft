namespace PWC.PSDToLevel.LevelContextualAnimation;

public class LevelCALabeledItemOnDropAreaHandler : LevelCAConditionalFieldHandlerBase
{
	[SerializeField]
	private string _label; //Field offset: 0x20
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x28

	public LevelCALabeledItemOnDropAreaHandler() { }

	public virtual bool IsConditionMet(ICATarget target) { }

}

