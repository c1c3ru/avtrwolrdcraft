namespace PazuCore;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public SoundManager <>4__this; //Field offset: 0x10
		public string clipName; //Field offset: 0x18
		public float volume; //Field offset: 0x20
		public float pitch; //Field offset: 0x24
		public int channel; //Field offset: 0x28
		public bool loop; //Field offset: 0x2C

		public <>c__DisplayClass13_0() { }

		internal void <PlayDelayed>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass15_0
	{
		public AudioClip clip; //Field offset: 0x10

		public <>c__DisplayClass15_0() { }

		internal void <Play>b__0() { }

	}

	public static SoundManager instance; //Field offset: 0x0
	private readonly Dictionary<Int32, AudioSource> _audioSources; //Field offset: 0x20
	private readonly Dictionary<String, String> _audioClipsPaths; //Field offset: 0x28
	private readonly Name_AudioEvent _soundsEvents; //Field offset: 0x30
	private readonly Dictionary<String, Int32> _soundEventIndexes; //Field offset: 0x38

	public IReadOnlyDictionary<Int32, AudioSource> AudioSources
	{
		 get { } //Length: 8
	}

	public SoundManager() { }

	public void AddAudioEvents(Name_AudioEvent audioEvents) { }

	private void Awake() { }

	public void EnsureAudioSource(int channel, out AudioSource audioSource) { }

	public IReadOnlyDictionary<Int32, AudioSource> get_AudioSources() { }

	public AudioClip GetAudioClip(string clipName, bool logErrorIfNotFound = true) { }

	public string GetCurrentClipPlayingName(int channel = 0) { }

	public float GetSoundLength(string clipName) { }

	public bool IsPlaying(int channel = 0) { }

	public void Play(string clipName, float volume = 1, float pitch = 1, int channel = 0, bool loop = false, bool forceKeepReference = false, bool forceNormalPlay = false) { }

	private AudioConfig PlayConfingEvent(string eventName, int configIndex, int channel, float overrideVolume = 0, float overridePitch = 0, bool randomStep = false) { }

	public void PlayDelayed(string clipName, float delay, float volume = 1, float pitch = 1, int channel = 0, bool loop = false) { }

	public List<AudioConfig> PlayEvent(string eventName, int channel = 0, float overrideVolume = 0, float overridePitch = 0, bool randomSteps = false) { }

	public void RemoveNotPlayingAudioSources() { }

	public void SetMute(bool mute, Int32[] excludeChannels) { }

	private void Start() { }

	public void Stop(int channel = 0) { }

	public bool TryGetPathForClipName(string clipName, out string path) { }

}

