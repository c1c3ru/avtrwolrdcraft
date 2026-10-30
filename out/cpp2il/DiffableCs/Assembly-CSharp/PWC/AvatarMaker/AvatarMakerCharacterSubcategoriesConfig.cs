namespace PWC.AvatarMaker;

public class AvatarMakerCharacterSubcategoriesConfig : AvatarMakerSubcategoriesConfigBase
{
	[SerializeField]
	private SerializableDictionaryBase<CharacterCategoryType, CharacterSubcategoryDataList> _subcategoriesData; //Field offset: 0x20

	public AvatarMakerCharacterSubcategoriesConfig() { }

	public virtual SerializableDictionaryBase<Int32, SubcategoryDataList> GetSubcategoriesData() { }

}

