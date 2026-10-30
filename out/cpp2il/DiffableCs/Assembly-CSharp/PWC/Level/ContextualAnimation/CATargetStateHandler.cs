namespace PWC.Level.ContextualAnimation;

public class CATargetStateHandler : MonoBehaviour
{
	public CACategoryType _categoryType; //Field offset: 0x20
	private readonly Dictionary<CACategoryType, Int32> _pagesForCategories; //Field offset: 0x28
	[CompilerGenerated]
	private bool <ShouldUseSavedPageIndex>k__BackingField; //Field offset: 0x30

	public private bool ShouldUseSavedPageIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public CATargetStateHandler() { }

	[CompilerGenerated]
	public bool get_ShouldUseSavedPageIndex() { }

	public void OnCAListUpdate() { }

	[CompilerGenerated]
	private void set_ShouldUseSavedPageIndex(bool value) { }

	public void SetCategoryType(CACategoryType categoryType) { }

	public void SetPageIndexForCurrentCategoryType(int pageIndex) { }

	public bool TryGetCategoryType(out CACategoryType categoryType) { }

	public bool TryGetPageIndexForCurrentCategoryType(out int pageIndex) { }

}

