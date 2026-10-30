namespace PazuCore;

public class AudioConfig
{
	public string audioClipId; //Field offset: 0x10
	public float volume; //Field offset: 0x18
	public float pitch; //Field offset: 0x1C
	public bool forceKeepReference; //Field offset: 0x20

	public AudioConfig() { }

}

