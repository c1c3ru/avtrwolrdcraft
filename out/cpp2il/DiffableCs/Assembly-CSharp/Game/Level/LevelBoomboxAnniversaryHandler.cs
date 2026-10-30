namespace Game.Level;

public class LevelBoomboxAnniversaryHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public int key; //Field offset: 0x10

		public <>c__DisplayClass3_0() { }

		internal bool <StopAnimationOnAllAvatars>b__0(LevelCharacter x) { }

	}

	private class AvatarAnimationSaver
	{
		public LevelCAConfig CAConfig; //Field offset: 0x10
		public LevelCAHandlerBase CAHandler; //Field offset: 0x18

		public AvatarAnimationSaver(LevelCAConfig caConfig, LevelCAHandlerBase caHandler) { }

	}

	private Dictionary<Int32, AvatarAnimationSaver> AvatarAnimationSaverDisctionary; //Field offset: 0x20
	private List<String> _animationsPlayedOnAllAvatars; //Field offset: 0x28

	public LevelBoomboxAnniversaryHandler() { }

	[CompilerGenerated]
	private void <DelayedStopAnimationOnAllAvatars>b__4_0() { }

	public void DelayedStopAnimationOnAllAvatars(float time) { }

	public void PlayAnimationOnAllAvatars(string reactionAnimationName) { }

	public void PlayAnimationOnAllAvatars(IReadOnlyList<String> reactionAnimationNames) { }

	public void StopAnimationOnAllAvatars() { }

}

