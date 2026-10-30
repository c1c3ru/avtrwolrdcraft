namespace PWC.Level;

public class LevelShakeHandler : MonoBehaviour
{
	[Header("Scene References")]
	[SerializeField]
	private GameObject[] _objectsToShake; //Field offset: 0x20
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x28
	[Header("Sound Settings")]
	[SerializeField]
	private string _shakeSoundName; //Field offset: 0x30
	[Range(0, 1)]
	[SerializeField]
	private float _volume; //Field offset: 0x38
	private bool _isShaking; //Field offset: 0x3C

	public LevelShakeHandler() { }

	[CompilerGenerated]
	private void <AnimateShake>b__7_0() { }

	public void AnimateShake(GameObject gameObject) { }

	public void PlaySound(string clipName) { }

	public void Shake(GameObject gameObject) { }

	public void ShakeAll() { }

}

