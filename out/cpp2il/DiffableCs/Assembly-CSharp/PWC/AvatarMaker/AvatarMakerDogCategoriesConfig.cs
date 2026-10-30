namespace PWC.AvatarMaker;

public class AvatarMakerDogCategoriesConfig : AvatarMakerCategoriesConfigBase
{
	[SerializeField]
	private List<DogCatrgoryData> _categoriesData; //Field offset: 0x20

	public AvatarMakerDogCategoriesConfig() { }

	public virtual List<CategoryData> GetCategoriesData() { }

}

