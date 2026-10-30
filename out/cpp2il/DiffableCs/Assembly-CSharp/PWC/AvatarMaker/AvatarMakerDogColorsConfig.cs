namespace PWC.AvatarMaker;

public class AvatarMakerDogColorsConfig : AvatarMakerColorsConfigBase
{
	[SerializeField]
	private SerializableDictionaryBase<DogCategoryType, AWSpineColorsList> _colorsByCategoryType; //Field offset: 0x20

	public AvatarMakerDogColorsConfig() { }

	public virtual SerializableDictionaryBase<Int32, AWSpineColorsList> GetColorLists() { }

}

