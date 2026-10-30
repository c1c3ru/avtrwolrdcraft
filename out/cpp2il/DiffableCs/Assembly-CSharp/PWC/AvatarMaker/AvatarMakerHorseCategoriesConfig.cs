namespace PWC.AvatarMaker;

public class AvatarMakerHorseCategoriesConfig : AvatarMakerCategoriesConfigBase
{
	[SerializeField]
	private List<HorseCatrgoryData> _categoriesData; //Field offset: 0x20

	public AvatarMakerHorseCategoriesConfig() { }

	public virtual List<CategoryData> GetCategoriesData() { }

}

