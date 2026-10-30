namespace PWC.AvatarMaker;

public class MakerExecuteColorTemplateAction : MakerExecuteActionBase
{
	private readonly int _categoryType; //Field offset: 0x10
	private readonly Color[] _colors; //Field offset: 0x18

	public MakerExecuteColorTemplateAction(int categoryType, Color[] colors) { }

	protected virtual void ExecuteActionInternal() { }

	protected virtual object GetRecoveryData() { }

	public static bool TryGetCurrentColors(AvatarSpineSkinsManagerBase spineSkinManager, int categoryType, out Color[] colors) { }

}

