namespace PWC.Level.Maker;

public class LevelMakerSplitLevelCamera : GameCameraBase
{
	private float _defaultYPosition; //Field offset: 0xC4

	public LevelMakerSplitLevelCamera() { }

	protected virtual void Awake() { }

	protected virtual Bounds1D GetDefaultBaseYBounds() { }

}

