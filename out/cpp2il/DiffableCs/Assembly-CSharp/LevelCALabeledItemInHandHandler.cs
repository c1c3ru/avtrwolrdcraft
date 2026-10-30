//Type is in global namespace

public class LevelCALabeledItemInHandHandler : LevelCAConditionalFieldHandlerBase
{
	[SerializeField]
	private string _label; //Field offset: 0x20
	[SerializeField]
	private bool _isDisallow; //Field offset: 0x28

	public LevelCALabeledItemInHandHandler() { }

	public virtual bool IsConditionMet(ICATarget target) { }

}

