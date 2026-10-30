namespace PWC.AvatarMaker;

public abstract class AvatarMakerCategoriesConfigBase : MonoBehaviour
{

	protected AvatarMakerCategoriesConfigBase() { }

	public abstract List<CategoryData> GetCategoriesData() { }

}

