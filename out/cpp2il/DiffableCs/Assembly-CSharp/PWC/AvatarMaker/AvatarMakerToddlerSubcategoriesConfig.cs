namespace PWC.AvatarMaker;

public class AvatarMakerToddlerSubcategoriesConfig : AvatarMakerSubcategoriesConfigBase
{
	[SerializeField]
	private SerializableDictionaryBase<ToddlerCategoryType, ToddlerSubcategoryDataList> _subcategoriesData; //Field offset: 0x20

	public AvatarMakerToddlerSubcategoriesConfig() { }

	public virtual SerializableDictionaryBase<Int32, SubcategoryDataList> GetSubcategoriesData() { }

}

