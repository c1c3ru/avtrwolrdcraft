namespace PWC.AvatarMaker;

public class AvatarMakerHorseSubcategoriesConfig : AvatarMakerSubcategoriesConfigBase
{
	[SerializeField]
	private SerializableDictionaryBase<HorseCategoryType, HorseSubcategoryDataList> _subcategoriesData; //Field offset: 0x20

	public AvatarMakerHorseSubcategoriesConfig() { }

	public virtual SerializableDictionaryBase<Int32, SubcategoryDataList> GetSubcategoriesData() { }

}

