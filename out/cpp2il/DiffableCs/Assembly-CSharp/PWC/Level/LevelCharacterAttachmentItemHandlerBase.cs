namespace PWC.Level;

[RequireComponent(typeof(LevelItem))]
public abstract class LevelCharacterAttachmentItemHandlerBase : MonoBehaviour, IInteractableItem, IMultiplayer_NetworkIdentityBase
{
	protected LevelItem _levelItem; //Field offset: 0x20
	[CompilerGenerated]
	private int <Multiplayer_ComponentIndex>k__BackingField; //Field offset: 0x28

	public override int Multiplayer_ComponentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	protected LevelCharacterAttachmentItemHandlerBase() { }

	protected override void Awake() { }

	public abstract bool CanInteractWithCharacter(LevelCharacter character) { }

	[CompilerGenerated]
	public override int get_Multiplayer_ComponentIndex() { }

	private string Multiplayer_GetKey() { }

	protected override void OnDestroy() { }

	public abstract void PutOnCharacter(LevelCharacter character, bool snap) { }

	private override void PWC.Multiplayer.MPDataHelper_ItemDropCharacterInteraction.IInteractableItem.Multiplayer_DropInteractWithCharacter(LevelCharacter character, MPEventIdentifierData idData) { }

	[CompilerGenerated]
	public override void set_Multiplayer_ComponentIndex(int value) { }

	private bool SnapItemToCharacter(ILevelAvatar avatar, ItemOnAvatarType type, LevelItem item) { }

	private void TryDropInteractionWithCharacter(LevelCharacter character, ref bool didInteract, ref MPEventIdentifierData mpData) { }

}

