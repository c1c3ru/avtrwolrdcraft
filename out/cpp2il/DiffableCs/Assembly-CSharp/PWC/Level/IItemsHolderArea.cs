namespace PWC.Level;

public interface IItemsHolderArea
{

	public event Action<LevelItem> OnItemsHolderItemEndDropAction
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	[CompilerGenerated]
	public void add_OnItemsHolderItemEndDropAction(Action<LevelItem> value) { }

	public bool HasItemsOnSelf() { }

	public void ReleaseItems() { }

	[CompilerGenerated]
	public void remove_OnItemsHolderItemEndDropAction(Action<LevelItem> value) { }

}

