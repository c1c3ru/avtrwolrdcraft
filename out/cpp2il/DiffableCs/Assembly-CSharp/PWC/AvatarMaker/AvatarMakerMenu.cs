namespace PWC.AvatarMaker;

public class AvatarMakerMenu : MonoBehaviour
{
	[SerializeField]
	private AvatarMakerThumbsManager _thumbsManager; //Field offset: 0x20
	[SerializeField]
	private AvatarMakerCategoriesManager _categoriesManager; //Field offset: 0x28
	[SerializeField]
	private AvatarMakerColorsManager _colorsManager; //Field offset: 0x30
	[SerializeField]
	private AvatarMakerMenuSpecialInteractionsManagerBase _specialInteractionsManager; //Field offset: 0x38
	[SerializeField]
	private AvatarMakerExpansionPackManager _expansionPackManager; //Field offset: 0x40

	public AvatarMakerCategoriesManager CategoriesManager
	{
		 get { } //Length: 8
	}

	public AvatarMakerColorsManager ColorsManager
	{
		 get { } //Length: 8
	}

	public AvatarMakerExpansionPackManager ExpansionPackManager
	{
		 get { } //Length: 8
	}

	public AvatarMakerMenuSpecialInteractionsManagerBase SpecialInteractionsManager
	{
		 get { } //Length: 8
	}

	public AvatarMakerThumbsManager ThumbsManager
	{
		 get { } //Length: 8
	}

	public AvatarMakerMenu() { }

	public AvatarMakerCategoriesManager get_CategoriesManager() { }

	public AvatarMakerColorsManager get_ColorsManager() { }

	public AvatarMakerExpansionPackManager get_ExpansionPackManager() { }

	public AvatarMakerMenuSpecialInteractionsManagerBase get_SpecialInteractionsManager() { }

	public AvatarMakerThumbsManager get_ThumbsManager() { }

	public void Init() { }

}

