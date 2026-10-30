namespace PWC.Level;

public class LevelScreenCaptureMakerItemHandler : LevelScreenCaptureHandler
{
	private LevelMakerItem _levelMakerItem; //Field offset: 0x80

	public LevelScreenCaptureMakerItemHandler() { }

	protected virtual void Awake() { }

	protected virtual bool CanCaptureShowItself() { }

	protected virtual void OnDestroy() { }

	private void OnMakerItemEndDrag(DragDropItemBase item, PointerEventData pointerData) { }

	private void OnSyncMakerItemIsFlippedState(LevelMakerItem levelMakerItem, bool isFlipped) { }

}

