namespace PWC.AvatarMaker;

public class AvatarMakerDogSubcategoriesConfig : AvatarMakerSubcategoriesConfigBase
{
	[SerializeField]
	private SerializableDictionaryBase<DogCategoryType, CatSubcategoryDataList> _subcategoriesData; //Field offset: 0x20

	public AvatarMakerDogSubcategoriesConfig() { }

	public virtual SerializableDictionaryBase<Int32, SubcategoryDataList> GetSubcategoriesData() { }

}

