namespace PWC.Level.Maker;

public class LevelMakerWallPanel : LevelMakerPanelBase
{
	public static readonly List<LevelObjectAreaBase> WallPanelsList; //Field offset: 0x0

	private static LevelMakerWallPanel() { }

	public LevelMakerWallPanel() { }

	protected virtual List<Vector2> GetDefaultPositionsForCurrentCameraView() { }

	protected virtual List<Vector2> GetPositionsForGoodPlaceToDropTest() { }

	protected virtual List<LevelObjectAreaBase> GetStaticAreasList() { }

}

