namespace PWC.AvatarMaker;

public class AvatarMakerCatSubcategoriesConfig : AvatarMakerSubcategoriesConfigBase
{
	[SerializeField]
	private SerializableDictionaryBase<CatCategoryType, CatSubcategoryDataList> _subcategoriesData; //Field offset: 0x20

	public AvatarMakerCatSubcategoriesConfig() { }

	public virtual SerializableDictionaryBase<Int32, SubcategoryDataList> GetSubcategoriesData() { }

}

