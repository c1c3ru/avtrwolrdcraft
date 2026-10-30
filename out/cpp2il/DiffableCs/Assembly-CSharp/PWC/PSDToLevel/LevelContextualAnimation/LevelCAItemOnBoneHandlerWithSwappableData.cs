namespace PWC.PSDToLevel.LevelContextualAnimation;

public class LevelCAItemOnBoneHandlerWithSwappableData : LevelCAItemOnBoneHandlerWithData, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	protected bool _saveDataPd; //Field offset: 0xA0
	protected ICATarget _target; //Field offset: 0xA8

	public LevelCAItemOnBoneHandlerWithSwappableData() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnAfterSwappingData() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public override void SwapData(LevelCAItemHandlerData data) { }

}

