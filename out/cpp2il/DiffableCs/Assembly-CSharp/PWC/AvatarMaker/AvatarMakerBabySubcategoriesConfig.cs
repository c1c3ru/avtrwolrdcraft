namespace PWC.AvatarMaker;

public class AvatarMakerBabySubcategoriesConfig : AvatarMakerSubcategoriesConfigBase
{
	[SerializeField]
	private SerializableDictionaryBase<BabyCategoryType, BabySubcategoryDataList> _subcategoriesData; //Field offset: 0x20

	public AvatarMakerBabySubcategoriesConfig() { }

	public virtual SerializableDictionaryBase<Int32, SubcategoryDataList> GetSubcategoriesData() { }

}

