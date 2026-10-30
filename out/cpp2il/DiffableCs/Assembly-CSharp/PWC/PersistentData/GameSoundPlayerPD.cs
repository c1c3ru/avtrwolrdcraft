namespace PWC.PersistentData;

public class GameSoundPlayerPD
{
	public bool isPlayingLoop; //Field offset: 0x10
	public string clipName; //Field offset: 0x18
	public float volume; //Field offset: 0x20
	public float pitch; //Field offset: 0x24

	public GameSoundPlayerPD() { }

}

