namespace PWC.Level;

[AddComponentMenu(null)]
public class LevelJugContainer : LevelContainerItemWithParticlesAndLiquid
{
	[SerializeField]
	private LevelDrinkableWithFillItemHandler _drinkableWithFillItemHandler; //Field offset: 0x378
	private int _tweenID; //Field offset: 0x380

	public LevelJugContainer() { }

	[CompilerGenerated]
	private void <OnEmpty>b__6_0() { }

	protected virtual void Animate(bool value) { }

	protected virtual void OnBeginDragSpecific() { }

	public void OnEmpty() { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	public void OnFull() { }

	public void OnIndicatorEnter() { }

	public void OnIndicatorExit() { }

}

