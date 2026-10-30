namespace PWC.Level;

public class LevelFillableJugContainer : LevelPouringItemHandler
{
	private int _tweenID; //Field offset: 0x80

	public LevelFillableJugContainer() { }

	[CompilerGenerated]
	private void <OnEmpty>b__4_0() { }

	public void OnEmpty() { }

	protected virtual void OnEndDrag(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	public void OnFull() { }

	public void OnIndicatorEnter() { }

	public void OnIndicatorExit() { }

	protected virtual bool TryAnimate(bool value) { }

}

