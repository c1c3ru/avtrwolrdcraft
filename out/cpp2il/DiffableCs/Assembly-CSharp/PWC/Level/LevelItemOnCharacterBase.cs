namespace PWC.Level;

public abstract class LevelItemOnCharacterBase : LevelItem
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public LevelCharacter character; //Field offset: 0x10

		public <>c__DisplayClass12_0() { }

		internal void <SnapItemToAvatar>b__0(TrackEntry x) { }

	}

	[SerializeField]
	private bool _requireStanding; //Field offset: 0x342
	[SerializeField]
	private bool _loop; //Field offset: 0x343
	private LevelCharacter _currentCharacter; //Field offset: 0x348
	private BoneFollower _currentBoneFollower; //Field offset: 0x350

	public bool RequireStanding
	{
		 get { } //Length: 8
	}

	protected LevelItemOnCharacterBase() { }

	public bool get_RequireStanding() { }

	protected abstract string GetCharacterAnimationName() { }

	protected abstract string GetCharacterBoneName() { }

	public virtual void Multiplayer_DropInteractWithCharacter(LevelCharacter character, MPEventIdentifierData idData) { }

	private string Multiplayer_GetKey() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	public virtual void OnPlacedOnAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	protected virtual void SnapItemToAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	public virtual bool TryDropInteractionWithCharacter(LevelCharacter character, out MPEventIdentifierData mpData) { }

	protected override bool UseItemInSpine() { }

}

