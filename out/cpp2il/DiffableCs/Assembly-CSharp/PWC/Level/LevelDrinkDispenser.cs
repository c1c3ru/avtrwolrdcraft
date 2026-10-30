namespace PWC.Level;

public class LevelDrinkDispenser : InteractableItem, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject, ILevelMakerDisabledWhileInEditMode
{
	[CompilerGenerated]
	private Action<Boolean> OnSyncStateAction; //Field offset: 0x40
	[SerializeField]
	protected LevelDrinkDispenserLiquid _liquid; //Field offset: 0x48
	[SerializeField]
	protected ParticleSystem _particleSystem; //Field offset: 0x50
	[SerializeField]
	protected string _onSound; //Field offset: 0x58
	[SerializeField]
	protected string _offSound; //Field offset: 0x60
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x68
	[SerializeField]
	protected string _loopSound; //Field offset: 0x70
	[Range(0, 1)]
	[SerializeField]
	private float _volume; //Field offset: 0x78
	[SerializeField]
	private bool _ignorePD; //Field offset: 0x7C
	[SerializeField]
	private bool _isNeedEnsurePlay; //Field offset: 0x7D
	[Header("Events")]
	[SerializeField]
	private UnityEvent _onSetStateOn; //Field offset: 0x80
	[SerializeField]
	private UnityEvent _onSetStateOff; //Field offset: 0x88
	protected bool _isOpen; //Field offset: 0x90
	private Coroutine _timer; //Field offset: 0x98

	public event Action<Boolean> OnSyncStateAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LevelDrinkDispenser() { }

	[CompilerGenerated]
	private void <ForceOnForDuration>b__24_0() { }

	[CompilerGenerated]
	public void add_OnSyncStateAction(Action<Boolean> value) { }

	private void EnsurePlayIfNeeded() { }

	public void ForceClick() { }

	public void ForceOnForDuration(float duration) { }

	public void ForceState(bool value) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	protected override void PlaySounds() { }

	[CompilerGenerated]
	public void remove_OnSyncStateAction(Action<Boolean> value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SetState(bool value) { }

	protected override void SyncState() { }

}

