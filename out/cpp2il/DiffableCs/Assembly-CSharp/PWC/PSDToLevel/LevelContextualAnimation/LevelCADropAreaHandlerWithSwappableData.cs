namespace PWC.PSDToLevel.LevelContextualAnimation;

public class LevelCADropAreaHandlerWithSwappableData : LevelCADropAreaHandlerWithData, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	protected bool _saveDataPd; //Field offset: 0x94
	protected LevelDropArea _dropArea; //Field offset: 0x98

	public LevelCADropAreaHandlerWithSwappableData() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnAfterSwappingData() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public override void SwapData(LevelCAItemHandlerData data) { }

}

