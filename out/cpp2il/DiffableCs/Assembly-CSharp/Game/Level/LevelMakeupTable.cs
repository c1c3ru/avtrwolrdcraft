namespace Game.Level;

public class LevelMakeupTable : LevelBoxItem
{
	[SerializeField]
	private GameObject _lights; //Field offset: 0x398
	[SerializeField]
	private List<LevelContainerArea> _sideContainerAreas; //Field offset: 0x3A0

	public LevelMakeupTable() { }

	[CompilerGenerated]
	private void <SyncState>b__2_0(LevelContainerArea sideContainerArea) { }

	protected virtual void SyncState() { }

}

