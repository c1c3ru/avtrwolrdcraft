namespace PWC.AvatarMaker;

public class AvatarMakerCharacterCategoriesConfig : AvatarMakerCategoriesConfigBase
{
	[SerializeField]
	private List<CharacterCatrgoryData> _categoriesData; //Field offset: 0x20

	public AvatarMakerCharacterCategoriesConfig() { }

	public virtual List<CategoryData> GetCategoriesData() { }

}

