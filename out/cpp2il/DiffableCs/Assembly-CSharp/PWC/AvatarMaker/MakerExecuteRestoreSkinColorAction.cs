namespace PWC.AvatarMaker;

public class MakerExecuteRestoreSkinColorAction : MakerExecuteActionBase
{
	private const int BODY_SHADOW_COLOR_INDEX = 0; //Field offset: 0x0
	private const int EAR_SHADOW_COLOR_INDEX = 1; //Field offset: 0x0
	private readonly Color _displayColor; //Field offset: 0x10
	private readonly Color[] _colors; //Field offset: 0x20

	public MakerExecuteRestoreSkinColorAction(Color displayColor, Color[] colors) { }

	protected virtual void ExecuteActionInternal() { }

	protected virtual object GetRecoveryData() { }

	public static bool TryGetCurrentSkinColorData(AvatarSpineSkinsManagerBase spineSkinManager, out SkinColorData skinColorData) { }

	private static bool TryGetFirstColor(AvatarSpineSkinsManagerBase spineSkinManager, int categoryType, out Color color) { }

}

