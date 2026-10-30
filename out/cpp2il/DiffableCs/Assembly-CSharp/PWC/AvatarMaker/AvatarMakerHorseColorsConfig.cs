namespace PWC.AvatarMaker;

public class AvatarMakerHorseColorsConfig : AvatarMakerColorsConfigBase
{
	[SerializeField]
	private SerializableDictionaryBase<HorseCategoryType, AWSpineColorsList> _colorsByCategoryType; //Field offset: 0x20

	public AvatarMakerHorseColorsConfig() { }

	public virtual SerializableDictionaryBase<Int32, AWSpineColorsList> GetColorLists() { }

}

