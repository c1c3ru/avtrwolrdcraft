namespace PWC.LevelContextualAnimation;

public class LevelCAConfig
{
	public string name; //Field offset: 0x10
	public int repetitions; //Field offset: 0x18
	public bool ensureRequiredTextures; //Field offset: 0x1C
	public string folderNameOverride; //Field offset: 0x20
	public int index; //Field offset: 0x28
	public bool isNameFullAnimationName; //Field offset: 0x2C
	public string thumbPathOverride; //Field offset: 0x30
	public string alternateIdleAnimation; //Field offset: 0x38
	public string preAnimation; //Field offset: 0x40
	public int trackIndex; //Field offset: 0x48
	public bool isDisableOtherAnimations; //Field offset: 0x4C
	public string extraData; //Field offset: 0x50
	public bool keepCurrentAnimation; //Field offset: 0x58

	public LevelCAConfig() { }

	public LevelCAConfig(string name, int repetitions = 0, bool ensureRequiredTextures = false, string folderNameOverride = null, bool isNameFullAnimationName = false, string thumbPathOverride = null, string alternateIdleAnimation = null, string preAnimation = null, int trackIndex = 0, string extraData = null) { }

	public static string CreateAnimationName(LevelCAHandlerBase handler, LevelCAConfig config) { }

	public static Sprite GetAnimationThumb(LevelCAHandlerBase handler, LevelCAConfig config, bool logIfErrors = true) { }

	public bool IsValid() { }

}

