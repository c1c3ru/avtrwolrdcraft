namespace Game.Level;

public class UnityEventBehaviour : MonoBehaviour
{
	[Header("LevelManager Callbacks Invokes")]
	[SerializeField]
	private bool _performOnPreInit; //Field offset: 0x20
	[SerializeField]
	private bool _performOnPrePostInit; //Field offset: 0x21
	[SerializeField]
	private bool _performOnPostInit; //Field offset: 0x22
	[Header("PersistentDataManager Callbacks Invokes")]
	[SerializeField]
	private bool _performOnPreSaveProgress; //Field offset: 0x23
	[SerializeField]
	private bool _performOnPostSaveProgress; //Field offset: 0x24
	[Header("Unity Callbacks Invokes")]
	[SerializeField]
	private bool _performOnAwake; //Field offset: 0x25
	[SerializeField]
	private bool _performOnDestroy; //Field offset: 0x26
	[SerializeField]
	private bool _performOnEnable; //Field offset: 0x27
	[SerializeField]
	private bool _performOnDisable; //Field offset: 0x28
	[Header("Event")]
	[SerializeField]
	[Space]
	private UnityEvent _event; //Field offset: 0x30

	public UnityEventBehaviour() { }

	private void Awake() { }

	public void Invoke() { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnPostInit() { }

	private void OnPostSaveProgress(Scene _) { }

	private void OnPreInit() { }

	private void OnPrePostInit() { }

	private void OnPreSaveProgress(Scene _) { }

}

