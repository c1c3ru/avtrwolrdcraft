namespace PazuCore;

[CreateAssetMenu]
public class AudioClipPaths : ScriptableObject
{
	internal class AudioClipPath
	{
		public string name; //Field offset: 0x10
		public string path; //Field offset: 0x18

		public AudioClipPath() { }

	}

	public List<AudioClipPath> paths; //Field offset: 0x18

	public AudioClipPaths() { }

}

