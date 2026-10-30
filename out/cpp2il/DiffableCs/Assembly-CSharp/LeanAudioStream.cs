//Type is in global namespace

public class LeanAudioStream
{
	public int position; //Field offset: 0x10
	public AudioClip audioClip; //Field offset: 0x18
	public Single[] audioArr; //Field offset: 0x20

	public LeanAudioStream(Single[] audioArr) { }

	public void OnAudioRead(Single[] data) { }

	public void OnAudioSetPosition(int newPosition) { }

}

