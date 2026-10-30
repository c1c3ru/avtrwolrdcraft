namespace Game.Store;

public class FocusOnCategoryStoreButton : ButtonBase
{
	[SerializeField]
	private string _storeCategoryName; //Field offset: 0x20
	[SerializeField]
	private string _soundName; //Field offset: 0x28

	public FocusOnCategoryStoreButton() { }

	protected virtual void OnClick() { }

}

