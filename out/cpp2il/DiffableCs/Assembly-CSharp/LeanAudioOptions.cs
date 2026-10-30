//Type is in global namespace

public class LeanAudioOptions
{
	internal enum LeanAudioWaveStyle
	{
		Sine = 0,
		Square = 1,
		Sawtooth = 2,
		Noise = 3,
	}

	public LeanAudioWaveStyle waveStyle; //Field offset: 0x10
	public Vector3[] vibrato; //Field offset: 0x18
	public Vector3[] modulation; //Field offset: 0x20
	public int frequencyRate; //Field offset: 0x28
	public float waveNoiseScale; //Field offset: 0x2C
	public float waveNoiseInfluence; //Field offset: 0x30
	public bool useSetData; //Field offset: 0x34
	public LeanAudioStream stream; //Field offset: 0x38

	public LeanAudioOptions() { }

	public LeanAudioOptions setFrequency(int frequencyRate) { }

	public LeanAudioOptions setVibrato(Vector3[] vibrato) { }

	public LeanAudioOptions setWaveNoise() { }

	public LeanAudioOptions setWaveNoiseInfluence(float influence) { }

	public LeanAudioOptions setWaveNoiseScale(float waveScale) { }

	public LeanAudioOptions setWaveSawtooth() { }

	public LeanAudioOptions setWaveSine() { }

	public LeanAudioOptions setWaveSquare() { }

	public LeanAudioOptions setWaveStyle(LeanAudioWaveStyle style) { }

}

