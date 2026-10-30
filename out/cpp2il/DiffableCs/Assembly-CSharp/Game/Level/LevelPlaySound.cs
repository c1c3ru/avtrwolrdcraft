namespace Game.Level;

public class LevelPlaySound : MonoBehaviour
{
	[SerializeField]
	private string _soundName; //Field offset: 0x20
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x28

	public LevelPlaySound() { }

	public void ForcePlayLooping() { }

	public void ForcePlayOneShot() { }

	public void ForceStop() { }

	public void Play() { }

}

