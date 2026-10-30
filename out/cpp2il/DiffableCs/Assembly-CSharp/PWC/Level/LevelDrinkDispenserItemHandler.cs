namespace PWC.Level;

public class LevelDrinkDispenserItemHandler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject, ILevelMakerDisabledWhileInEditMode
{
	[CompilerGenerated]
	private Action<Boolean> OnSyncStateAction; //Field offset: 0x20
	[SerializeField]
	protected LevelDrinkDispenserLiquid _liquid; //Field offset: 0x28
	[SerializeField]
	protected ParticleSystem _particleSystem; //Field offset: 0x30
	[SerializeField]
	protected string _onSound; //Field offset: 0x38
	[SerializeField]
	protected string _offSound; //Field offset: 0x40
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x48
	[SerializeField]
	protected string _loopSound; //Field offset: 0x50
	[Range(0, 1)]
	[SerializeField]
	private float _volume; //Field offset: 0x58
	[SerializeField]
	private bool _ignorePD; //Field offset: 0x5C
	[Header("Events")]
	[SerializeField]
	private UnityEvent _onSetStateOn; //Field offset: 0x60
	[SerializeField]
	private UnityEvent _onSetStateOff; //Field offset: 0x68
	protected bool _isOpen; //Field offset: 0x70

	public event Action<Boolean> OnSyncStateAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LevelDrinkDispenserItemHandler() { }

	[CompilerGenerated]
	public void add_OnSyncStateAction(Action<Boolean> value) { }

	public void ForceClick() { }

	public void ForceState(bool value) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	protected override void PlaySounds() { }

	[CompilerGenerated]
	public void remove_OnSyncStateAction(Action<Boolean> value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SetState(bool value) { }

	protected override void SyncState() { }

}

