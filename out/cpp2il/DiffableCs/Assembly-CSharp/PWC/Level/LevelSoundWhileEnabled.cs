namespace PWC.Level;

public class LevelSoundWhileEnabled : MonoBehaviour
{
	[SerializeField]
	private bool _isLoop; //Field offset: 0x20
	[SerializeField]
	private string _soundName; //Field offset: 0x28
	[SerializeField]
	private float _volume; //Field offset: 0x30
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x38
	[SerializeField]
	private bool _waitPostInit; //Field offset: 0x40

	public LevelSoundWhileEnabled() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnPostInitAction() { }

	private void PlaySound() { }

	private void StopSound() { }

}

