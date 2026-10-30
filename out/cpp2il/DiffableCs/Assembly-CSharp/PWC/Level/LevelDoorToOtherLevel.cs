namespace PWC.Level;

public class LevelDoorToOtherLevel : LevelLevelSwitcher
{
	private const int TRACK_INDEX = 0; //Field offset: 0x0
	private const string CLOSE_ANIMATION_NAME = "close"; //Field offset: 0x0
	private const string CLOSE_IDLE_ANIMATION_NAME = "close_idle"; //Field offset: 0x0
	private const string OPEN_ANIMATION_NAME = "open"; //Field offset: 0x0
	private const string OPEN_IDLE_ANIMATION_NAME = "open_idle"; //Field offset: 0x0
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x48
	private bool _didBecomeVisible; //Field offset: 0x50

	public LevelDoorToOtherLevel() { }

	[CompilerGenerated]
	private void <OnBecameVisible>b__7_0() { }

	[CompilerGenerated]
	private void <OnBecameVisible>b__7_1() { }

	private void OnBecameVisible() { }

}

