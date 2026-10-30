namespace PWC.AvatarMaker;

public class AvatarMakerCatCategoriesConfig : AvatarMakerCategoriesConfigBase
{
	[SerializeField]
	private List<CatCatrgoryData> _categoriesData; //Field offset: 0x20

	public AvatarMakerCatCategoriesConfig() { }

	public virtual List<CategoryData> GetCategoriesData() { }

}

