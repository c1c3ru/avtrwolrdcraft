namespace PWC.AvatarMaker;

public class AvatarMakerSubcategory : AvatarMakerCategory
{
	private Vector2 _indicatorInitialSizeDelta; //Field offset: 0x6C

	public AvatarMakerSubcategory() { }

	public void AnimatePunchScale() { }

	public virtual void ForceClick() { }

	public void ForceDisable() { }

	public virtual void Init(AvatarMakerCategoriesManager manager, CategoryData categoryData, RectTransform indicator) { }

	protected virtual void OnCategoryButtonClick(int categoryType) { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

	public void SetSubcategoryData(SubcategoryData subcategoryData) { }

}

