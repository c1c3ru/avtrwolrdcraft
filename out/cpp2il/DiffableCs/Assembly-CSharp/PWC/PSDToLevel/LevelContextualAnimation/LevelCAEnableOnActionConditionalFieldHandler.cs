namespace PWC.PSDToLevel.LevelContextualAnimation;

public class LevelCAEnableOnActionConditionalFieldHandler : LevelCAConditionalFieldHandlerBase, IHasPersistentData, IRequirePDSceneObject
{
	private bool _isEnabled; //Field offset: 0x20

	public LevelCAEnableOnActionConditionalFieldHandler() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public virtual bool IsConditionMet(ICATarget target) { }

	public void SetEnabled(bool enabled) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

