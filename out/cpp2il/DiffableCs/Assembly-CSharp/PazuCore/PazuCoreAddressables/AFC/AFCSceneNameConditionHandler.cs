namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCSceneNameConditionHandler : AFCConditionHandlerBase
{
	[SerializeField]
	private SceneName _sceneName; //Field offset: 0x38

	public AFCSceneNameConditionHandler() { }

	public virtual bool IsConditionMet() { }

}

