namespace PWC.Level;

public abstract class LevelDoorToOtherLevelBase : LevelLevelSwitcher
{
	private bool _didBecomeVisible; //Field offset: 0x48

	protected LevelDoorToOtherLevelBase() { }

	[CompilerGenerated]
	private void <OnBecameInvisible>b__2_0() { }

	[CompilerGenerated]
	private void <OnBecameVisible>b__1_0() { }

	protected override float GetDelayDuration() { }

	private void OnBecameInvisible() { }

	private void OnBecameVisible() { }

	protected abstract void SetState(bool isOpen) { }

}

