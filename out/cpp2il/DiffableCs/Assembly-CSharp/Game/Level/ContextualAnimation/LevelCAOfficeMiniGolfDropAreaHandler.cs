namespace Game.Level.ContextualAnimation;

public class LevelCAOfficeMiniGolfDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private LevelDropArea _ballDropArea; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88
	private LevelDropArea _avatarDropArea; //Field offset: 0x90
	private GameObject _ball; //Field offset: 0x98

	private void _ballDropArea_OnItemEndDropAction(LevelItem obj) { }

	private void _ballDropArea_OnItemPickUpAction(LevelItem obj) { }

	public LevelCAOfficeMiniGolfDropAreaHandler() { }

	protected virtual void Awake() { }

	private bool CheckIsHoldingGolfClub(LevelCharacter character, AvatarHandType handType) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	protected virtual void OnDestroy() { }

}

