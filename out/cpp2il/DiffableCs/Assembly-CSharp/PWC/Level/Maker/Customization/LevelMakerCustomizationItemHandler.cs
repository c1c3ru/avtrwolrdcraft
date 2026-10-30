namespace PWC.Level.Maker.Customization;

public class LevelMakerCustomizationItemHandler : LevelMakerCustomizationObjectHandlerBase
{
	private DragDropItemBase _item; //Field offset: 0x40

	public LevelMakerCustomizationItemHandler() { }

	protected virtual void Awake() { }

	public virtual Bounds GetBoundsForMenu() { }

	private bool TryEnsureItem() { }

}

