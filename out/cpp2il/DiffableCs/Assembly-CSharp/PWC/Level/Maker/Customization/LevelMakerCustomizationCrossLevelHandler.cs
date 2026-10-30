namespace PWC.Level.Maker.Customization;

public class LevelMakerCustomizationCrossLevelHandler : MonoBehaviour, IHasCrossSceneObjectGuid
{

	public LevelMakerCustomizationCrossLevelHandler() { }

	private void Awake() { }

	private string GetKey(string sceneGuid) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnPreSaveProgress(Scene scene) { }

	private bool TryGetComponentAndSceneGuid(out LevelMakerCustomizationHandlerBase customizationHandler, out string sceneGuid) { }

}

