namespace PWC.AvatarMaker;

public abstract class AvatarMakerSubcategoriesConfigBase : MonoBehaviour
{

	protected AvatarMakerSubcategoriesConfigBase() { }

	public abstract SerializableDictionaryBase<Int32, SubcategoryDataList> GetSubcategoriesData() { }

	public override bool HasPlaceForSubcategory(int categoryType) { }

	public override bool TryGetDefaultSubcategory(int parentCategoryType, out int subcategoryType) { }

}

