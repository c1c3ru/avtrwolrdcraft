namespace PWC.Level;

public class LevelScreenCaptureCameraItemHandler : LevelScreenCaptureItemHandler
{

	public LevelScreenCaptureCameraItemHandler() { }

	protected virtual bool CanCaptureShowItself() { }

	protected virtual bool IsFlipablePreview() { }

}

