//Type is in global namespace

public class LeanAudio
{
	public static float MIN_FREQEUNCY_PERIOD; //Field offset: 0x0
	public static int PROCESSING_ITERATIONS_MAX; //Field offset: 0x4
	public static Single[] generatedWaveDistances; //Field offset: 0x8
	public static int generatedWaveDistancesCount; //Field offset: 0x10
	private static Single[] longList; //Field offset: 0x18

	private static LeanAudio() { }

	public LeanAudio() { }

	public static AudioClip createAudio(AnimationCurve volume, AnimationCurve frequency, LeanAudioOptions options = null) { }

	private static AudioClip createAudioFromWave(int waveLength, LeanAudioOptions options) { }

	public static LeanAudioStream createAudioStream(AnimationCurve volume, AnimationCurve frequency, LeanAudioOptions options = null) { }

	private static int createAudioWave(AnimationCurve volume, AnimationCurve frequency, LeanAudioOptions options) { }

	public static AudioClip generateAudioFromCurve(AnimationCurve curve, int frequencyRate = 44100) { }

	private static void OnAudioSetPosition(int newPosition) { }

	public static LeanAudioOptions options() { }

	public static AudioSource play(AudioClip audio, float volume) { }

	public static AudioSource play(AudioClip audio) { }

	public static AudioSource play(AudioClip audio, Vector3 pos) { }

	public static AudioSource play(AudioClip audio, Vector3 pos, float volume) { }

	public static AudioSource playClipAt(AudioClip clip, Vector3 pos) { }

	public static void printOutAudioClip(AudioClip audioClip, ref AnimationCurve curve, float scaleX = 1) { }

}

