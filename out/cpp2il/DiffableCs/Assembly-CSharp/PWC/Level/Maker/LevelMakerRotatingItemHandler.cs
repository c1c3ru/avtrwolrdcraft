namespace PWC.Level.Maker;

public class LevelMakerRotatingItemHandler : LevelMakerRotatingItemHandlerBase, ILevelMakerRotatableByUIItem
{

	public LevelMakerRotatingItemHandler() { }

	public void ForceRotateItem() { }

	protected virtual void OnItemRotated(LevelMakerRotatingItemHandlerBase nextRotationItem) { }

	private override bool PWC.Level.Maker.ILevelMakerRotatableByUIItem.CanRotateNow() { }

	private override string PWC.Level.Maker.ILevelMakerRotatableByUIItem.GetTargetPrefabGuid() { }

	private override void PWC.Level.Maker.ILevelMakerRotatableByUIItem.RotateByUIButton() { }

}

