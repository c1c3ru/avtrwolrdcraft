namespace PWC.Level;

public class LevelSecretContentButton : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[FormerlySerializedAs("_defaultFlavors")]
	[SerializeField]
	private GameObject _defaultContent; //Field offset: 0x20
	[FormerlySerializedAs("_secretFlavors")]
	[SerializeField]
	private GameObject _secretContent; //Field offset: 0x28
	[SerializeField]
	private LevelButton _button; //Field offset: 0x30
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x38
	private bool _isPressed; //Field offset: 0x40
	private bool _isInteractable; //Field offset: 0x41

	public LevelSecretContentButton() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public void OnClick() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public override void ToggleState() { }

	private void UpdateDisplay() { }

}

