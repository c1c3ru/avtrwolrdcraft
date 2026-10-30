namespace PWC.AvatarMaker;

public class MakerExecuteRestoreTemplateAction : MakerExecuteActionBase
{
	private readonly TemplateRestoreData _templateRestoreData; //Field offset: 0x10

	public MakerExecuteRestoreTemplateAction(TemplateRestoreData templateRestoreData) { }

	protected virtual void ExecuteActionInternal() { }

	protected virtual object GetRecoveryData() { }

	private void HandleRemovedSkin(string removedSkinName) { }

}

