namespace PWC.Level.ContextualAnimation;

public abstract class LevelCAItemHandlerBase : LevelCAHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public LevelCAItemHandlerBase <>4__this; //Field offset: 0x10
		public LevelItemInCharacterBoneTransformOverride itemInCharacterBoneTransformOverride; //Field offset: 0x18

		public <>c__DisplayClass6_0() { }

		internal void <EnsureHand>b__0() { }

	}

	protected LevelItem _levelItem; //Field offset: 0x80

	protected LevelCAItemHandlerBase() { }

	protected virtual void Awake() { }

	public override bool CanBePutOnSleepingAvatar() { }

	private void CanPutInCharacterHand(LevelCharacter character, ref bool canPutInHand) { }

	public void DropFromCurrentHolder() { }

	protected void DropFromHand(LevelCharacter character) { }

	protected void DropFromMouth(ILevelHasMouth mouthOwner) { }

	protected void EnsureHand(ILevelHasHands target, AvatarHandType characterHandType) { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	protected virtual void OnDestroy() { }

	protected void ReleaseOtherItems(LevelCharacter character) { }

	protected void SetItemPivot(Vector2 pivot, bool snap) { }

	protected override bool SnapItemToAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType, LevelItem levelItem) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

	protected bool TrySwitchHands(LevelToddler toddler, bool snap) { }

	protected bool TrySwitchHands(LevelCharacter character, bool snap) { }

}

