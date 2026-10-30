namespace PWC.AvatarMaker;

public class AvatarMakerToddlerCategoriesConfig : AvatarMakerCategoriesConfigBase
{
	[SerializeField]
	private List<ToddlerCatrgoryData> _categoriesData; //Field offset: 0x20

	public AvatarMakerToddlerCategoriesConfig() { }

	public virtual List<CategoryData> GetCategoriesData() { }

}

