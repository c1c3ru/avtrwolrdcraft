namespace PWC.Level.Maker;

public class LevelMakerSplitLevelViewSlider : GameUIElement, IBeginDragHandler, IEventSystemHandler, IDragHandler
{
	private int _tweenId; //Field offset: 0x24
	private Vector2 _offset; //Field offset: 0x28

	public LevelMakerSplitLevelViewSlider() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnSplitLevelModeChange(bool value) { }

	private override void UnityEngine.EventSystems.IBeginDragHandler.OnBeginDrag(PointerEventData eventData) { }

	private override void UnityEngine.EventSystems.IDragHandler.OnDrag(PointerEventData eventData) { }

}

