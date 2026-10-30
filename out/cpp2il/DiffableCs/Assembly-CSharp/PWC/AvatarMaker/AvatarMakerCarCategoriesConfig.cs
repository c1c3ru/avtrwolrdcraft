namespace PWC.AvatarMaker;

public class AvatarMakerCarCategoriesConfig : AvatarMakerCategoriesConfigBase
{
	[SerializeField]
	private List<CarCategoryData> _categoriesData; //Field offset: 0x20

	public AvatarMakerCarCategoriesConfig() { }

	public virtual List<CategoryData> GetCategoriesData() { }

}

