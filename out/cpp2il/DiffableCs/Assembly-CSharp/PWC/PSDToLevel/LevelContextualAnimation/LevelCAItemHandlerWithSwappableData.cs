namespace PWC.PSDToLevel.LevelContextualAnimation;

public class LevelCAItemHandlerWithSwappableData : LevelCAItemHandlerWithData, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	protected bool _saveDataPd; //Field offset: 0x90
	protected ICATarget _target; //Field offset: 0x98

	public LevelCAItemHandlerWithSwappableData() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnAfterSwappingData() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public override void SwapData(LevelCAItemHandlerData data) { }

}

