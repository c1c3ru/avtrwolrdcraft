namespace PWC.Level;

[AddComponentMenu(null)]
public class LevelCharacterAttachmentItemHandler : LevelCharacterAttachmentItemHandlerBase
{
	private const string ROOT_BONE_NAME = "root"; //Field offset: 0x0

	public LevelCharacterAttachmentItemHandler() { }

	public virtual bool CanInteractWithCharacter(LevelCharacter character) { }

	public virtual void PutOnCharacter(LevelCharacter character, bool snap) { }

}

