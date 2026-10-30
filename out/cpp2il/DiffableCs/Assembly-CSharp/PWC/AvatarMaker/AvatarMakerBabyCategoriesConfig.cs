namespace PWC.AvatarMaker;

public class AvatarMakerBabyCategoriesConfig : AvatarMakerCategoriesConfigBase
{
	[SerializeField]
	private List<BabyCatrgoryData> _categoriesData; //Field offset: 0x20

	public AvatarMakerBabyCategoriesConfig() { }

	public virtual List<CategoryData> GetCategoriesData() { }

}

