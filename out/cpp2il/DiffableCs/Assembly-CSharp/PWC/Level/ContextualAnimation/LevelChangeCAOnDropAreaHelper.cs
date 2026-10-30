namespace PWC.Level.ContextualAnimation;

public class LevelChangeCAOnDropAreaHelper : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelCAItemHandlerData _firstCAHandler; //Field offset: 0x20
	[SerializeField]
	private LevelCAItemHandlerData _secondCAHandler; //Field offset: 0x28
	[SerializeField]
	private LevelCADropAreaHandlerWithData _levelCADropAreaHandlerWithData; //Field offset: 0x30
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x38
	private ICATarget _target; //Field offset: 0x40
	private bool _isFirstCA; //Field offset: 0x48

	public LevelChangeCAOnDropAreaHelper() { }

	private void ApplyCAData() { }

	private void Awake() { }

	public void ChangeToFirstCAHandler() { }

	public void ChangeToSecondCAHandler() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void OnItemPickUp(LevelItem levelItem) { }

	private void OnPostInit() { }

	private void SetIsFirstCA(bool isFirstCA) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void ToggleCA() { }

}

