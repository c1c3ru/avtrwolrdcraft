namespace PWC.AvatarMaker;

public class AvatarMakerToddlerColorsConfig : AvatarMakerColorsConfigBase
{
	[SerializeField]
	private SerializableDictionaryBase<ToddlerCategoryType, AWSpineColorsList> _colorsByCategoryType; //Field offset: 0x20

	public AvatarMakerToddlerColorsConfig() { }

	public virtual SerializableDictionaryBase<Int32, AWSpineColorsList> GetColorLists() { }

}

