namespace PWC.AvatarMaker;

public class AvatarMakerCarSubcategoriesConfig : AvatarMakerSubcategoriesConfigBase
{
	[SerializeField]
	private SerializableDictionaryBase<CarCategoryType, CarSubcategoryDataList> _subcategoriesData; //Field offset: 0x20

	public AvatarMakerCarSubcategoriesConfig() { }

	public virtual SerializableDictionaryBase<Int32, SubcategoryDataList> GetSubcategoriesData() { }

	public virtual bool HasPlaceForSubcategory(int categoryType) { }

	public virtual bool TryGetDefaultSubcategory(int parentCategoryType, out int subcategoryType) { }

}

