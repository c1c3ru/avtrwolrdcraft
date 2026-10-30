namespace PWC.Level;

public class LevelAvatarRestAreaEventOnAvatarDropHandler : MonoBehaviour, ILevelSpawnDuringGameplay
{
	[Header("First Drop Event")]
	[Header("Drop Events")]
	[SerializeField]
	private bool _invokeFirstAvatarDropSeperatly; //Field offset: 0x20
	[SerializeField]
	protected bool _invokeFirstDropEventOnPostInit; //Field offset: 0x21
	[SerializeField]
	public UnityEvent OnFirstAvatarDropAction; //Field offset: 0x28
	[Header("Drop Event")]
	[SerializeField]
	protected bool _invokeDropEventOnPostInit; //Field offset: 0x30
	[SerializeField]
	public UnityEvent OnAvatarDropAction; //Field offset: 0x38
	[Header("Pick Up Events")]
	[Header("Empty Area Event")]
	[SerializeField]
	[Space]
	private bool _invokeEmptyAvatarRestAreaBaseSeperatly; //Field offset: 0x40
	[SerializeField]
	protected bool _invokeEmptyAreaEventOnPostInit; //Field offset: 0x41
	[SerializeField]
	public UnityEvent OnAvatarRestAreaBaseEmptyAction; //Field offset: 0x48
	[Header("Pick Up Event")]
	[SerializeField]
	protected bool _invokePickUpEventOnPostInit; //Field offset: 0x50
	[SerializeField]
	public UnityEvent OnAvatarPickUpAction; //Field offset: 0x58
	private LevelAvatarRestAreaBase _avatarRestAreaBase; //Field offset: 0x60

	public LevelAvatarRestAreaEventOnAvatarDropHandler() { }

	protected override void Awake() { }

	private void EnsureOnReadyPostLoad() { }

	protected override void OnAvatarEndDrop(LevelAvatarRestAreaBase _, ILevelAvatar __) { }

	protected override void OnAvatarPickUp(LevelAvatarRestAreaBase _, ILevelAvatar __) { }

	private void OnDestroy() { }

	public void OnLevelPostInit() { }

	public override void OnSpawnDuringGameplay() { }

}

