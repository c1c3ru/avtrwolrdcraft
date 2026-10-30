namespace PWC.Level.Maker;

public class LevelMakerFloorPanel : LevelMakerPanelBase
{
	[CompilerGenerated]
	private struct <>c__DisplayClass7_0
	{
		public Dictionary<String, PDSceneObject> sceneObjects; //Field offset: 0x0

	}

	public static readonly List<LevelObjectAreaBase> FloorPanelsList; //Field offset: 0x0

	private static LevelMakerFloorPanel() { }

	public LevelMakerFloorPanel() { }

	[CompilerGenerated]
	internal static MeshSkew <SetPersistentData>g__GetMeshSkewFromGuid|7_0(string sceneGuid, ref <>c__DisplayClass7_0 unnamed_param_1) { }

	public virtual void DestroyAndReleaseItems() { }

	protected virtual List<Vector2> GetDefaultPositionsForCurrentCameraView() { }

	protected virtual Vector2 GetDragPositionForThisFramePostModifications(Vector2 position) { }

	private float GetHeightOfFloor(MeshSkew floor) { }

	private float GetMiddleHeightOfFloor(MeshSkew floor) { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual List<LevelObjectAreaBase> GetStaticAreasList() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

