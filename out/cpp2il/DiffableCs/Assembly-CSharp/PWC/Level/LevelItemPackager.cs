namespace PWC.Level;

[DisallowMultipleComponent]
public class LevelItemPackager : MonoBehaviour
{
	[SerializeField]
	protected PDPrefabReference[] _packagesPrefabReferences; //Field offset: 0x20
	[SerializeField]
	private LevelDropArea _packagerDropArea; //Field offset: 0x28
	[SerializeField]
	private bool _useEffectColorHandler; //Field offset: 0x30
	[ConditionalField("_useEffectColorHandler", False, True, (array) null)]
	[SerializeField]
	private Color _particleSystemColor; //Field offset: 0x34
	[SerializeField]
	private ParticleSystem _overrideEffectPrefab; //Field offset: 0x48
	[SerializeField]
	private bool _dontRestoreOnSceneLoad; //Field offset: 0x50
	[SerializeField]
	private string _soundName; //Field offset: 0x58
	[SerializeField]
	private bool _shouldAutoWorkOnDrop; //Field offset: 0x60
	private bool _isWorking; //Field offset: 0x61
	private LevelItem _pendingItem; //Field offset: 0x68

	public LevelItemPackager() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnItemEndDropAction(LevelItem item) { }

	private void OnItemPickUpAction(LevelItem item) { }

	public void PackageItem() { }

}

