namespace PWC;

public static class SoundChannelsManager
{
	private const int SOUND_CHANNEL_START = 1000; //Field offset: 0x0
	private static int _nextSoundChannel; //Field offset: 0x0
	private static readonly List<Int32> _availableChannels; //Field offset: 0x8
	private static readonly Dictionary<GameObject, Int32> _soundChannels; //Field offset: 0x10

	private static SoundChannelsManager() { }

	public static int AssignSoundChannel(GameObject gameObject) { }

	public static void ReleaseSoundChannel(GameObject gameObject) { }

}

