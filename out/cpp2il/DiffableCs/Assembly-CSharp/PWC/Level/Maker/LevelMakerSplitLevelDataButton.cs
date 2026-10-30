namespace PWC.Level.Maker;

public class LevelMakerSplitLevelDataButton : GameUIElement, IPointerClickHandler, IEventSystemHandler
{
	private static LevelMakerSplitLevelDataButton _current; //Field offset: 0x0
	[SerializeField]
	private Image _frame; //Field offset: 0x28
	[SerializeField]
	private WarehouseType _warehouseType; //Field offset: 0x30
	private int _tweenId; //Field offset: 0x34

	public LevelMakerSplitLevelDataButton() { }

	public void ForceClick() { }

	private string GetDataName() { }

	private void Select() { }

	private void SetSelected(bool selected) { }

	private override void UnityEngine.EventSystems.IPointerClickHandler.OnPointerClick(PointerEventData eventData) { }

}

