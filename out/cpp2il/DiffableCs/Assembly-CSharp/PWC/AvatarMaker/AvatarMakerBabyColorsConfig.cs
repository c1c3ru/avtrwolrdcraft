namespace PWC.AvatarMaker;

public class AvatarMakerBabyColorsConfig : AvatarMakerColorsConfigBase
{
	[SerializeField]
	private SerializableDictionaryBase<BabyCategoryType, AWSpineColorsList> _colorsByCategoryType; //Field offset: 0x20

	public AvatarMakerBabyColorsConfig() { }

	public virtual SerializableDictionaryBase<Int32, AWSpineColorsList> GetColorLists() { }

}

