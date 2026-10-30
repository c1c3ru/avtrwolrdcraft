namespace PWC.Level;

public class LevelGreenScreenSpriteRenderer : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[Header("Project References")]
	[SerializeField]
	private GreenScreenTexturesData _texturesData; //Field offset: 0x20
	[Header("Settings")]
	[SerializeField]
	private bool _loop; //Field offset: 0x28
	private SpriteRenderer _spriteRenderer; //Field offset: 0x30
	private int _currentIndex; //Field offset: 0x38
	public Action<String> OnSetTextureLabelAction; //Field offset: 0x40

	public LevelGreenScreenSpriteRenderer() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnPostInitHandler() { }

	private override Dictionary<String, Object> PWC.PersistentData.IHasPersistentData.GetPersistentData() { }

	private override void PWC.PersistentData.IHasPersistentData.SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetNextTexture() { }

	public void SetPreviousTexture() { }

	public void SetTextureByIndex(int index) { }

	private void TryOverrideOnClaimSuccess(StoreClaimItemCloudResponse response, ref bool didOverride) { }

	private bool TrySetTexture(int index) { }

	private bool TrySetTexture(string label) { }

}

