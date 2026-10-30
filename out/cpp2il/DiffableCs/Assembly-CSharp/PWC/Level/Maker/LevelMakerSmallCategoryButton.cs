namespace PWC.Level.Maker;

public class LevelMakerSmallCategoryButton : LevelMakerCategoryButton
{
	private static LevelMakerSmallCategoryButton _selected; //Field offset: 0x0
	[SerializeField]
	private GameObject _selectedIndicator; //Field offset: 0x70

	public LevelMakerSmallCategoryButton() { }

	public void OnDeselect() { }

	private void OnDestroy() { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

	public void OnSelect() { }

}

