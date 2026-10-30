namespace PWC.Level;

public class LevelConsumerAreaSkinNameConditionHandler : LevelConsumerAreaConditionBase
{
	[SerializeField]
	private String[] _skinNames; //Field offset: 0x28
	[SerializeField]
	private bool _isDisallow; //Field offset: 0x30

	public LevelConsumerAreaSkinNameConditionHandler() { }

	[CompilerGenerated]
	private bool <CanConsumeItem>b__2_0(KeyValuePair<Int32, String> kvp) { }

	protected virtual void CanConsumeItem(LevelItem levelItem, ref bool canConsume) { }

}

