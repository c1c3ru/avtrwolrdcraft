namespace PWC.Level;

public class LevelNewCarManager : LevelNewAvatarManager
{
	private LevelPlayerVehicle _car; //Field offset: 0x40

	protected virtual bool RestoresDoneButtonFlagsOnReload
	{
		 get { } //Length: 8
	}

	public LevelNewCarManager() { }

	protected virtual bool get_RestoresDoneButtonFlagsOnReload() { }

	protected virtual void OnAvatarSpawnPostInit() { }

	protected virtual void SpawnAvatar() { }

}

