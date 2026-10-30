namespace PWC.AvatarMaker;

public class MakerExecuteRestoreAvatarAction : MakerExecuteActionBase
{
	private readonly AvatarSpineData _avatarSpineData; //Field offset: 0x10

	public MakerExecuteRestoreAvatarAction(AvatarSpineData avatarSpineData) { }

	protected virtual void ExecuteActionInternal() { }

	protected virtual object GetRecoveryData() { }

}

