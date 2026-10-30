namespace PWC.AvatarMaker;

public class AvatarMakerCharacterColorsConfig : AvatarMakerColorsConfigBase
{
	[SerializeField]
	private SerializableDictionaryBase<CharacterCategoryType, AWSpineColorsList> _colorsByCategoryType; //Field offset: 0x20

	public AvatarMakerCharacterColorsConfig() { }

	public virtual SerializableDictionaryBase<Int32, AWSpineColorsList> GetColorLists() { }

}

