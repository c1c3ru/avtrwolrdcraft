namespace Game.Level;

public class LevelMultiGivenToCharacterForExchangeItemHandlerBasedOnGUID : LevelGivenToCharacterForExchangeItemHandlerBasedOnGUID
{
	[SerializeField]
	private LevelMultiGivenToCharacterForExchangeItemHandlerBasedOnGUID[] multiExchangeItems; //Field offset: 0xA0
	[CompilerGenerated]
	private Action OnAllItemsGivenAction; //Field offset: 0xA8

	public event Action OnAllItemsGivenAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public LevelMultiGivenToCharacterForExchangeItemHandlerBasedOnGUID() { }

	[CompilerGenerated]
	public void add_OnAllItemsGivenAction(Action value) { }

	protected virtual bool IsReceivingGiftMeetsTheCondition() { }

	[CompilerGenerated]
	public void remove_OnAllItemsGivenAction(Action value) { }

}

