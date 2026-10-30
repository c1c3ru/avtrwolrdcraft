namespace PWC.Level;

public class LevelSoundOnEndDropItemHandler : MonoBehaviour
{
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x20
	[SerializeField]
	private string _soundName; //Field offset: 0x28
	[SerializeField]
	private bool _shouldDestroyAfterFirstFall; //Field offset: 0x30
	private LevelItem _levelItem; //Field offset: 0x38
	private bool _shouldPlaySoundEffect; //Field offset: 0x40

	public LevelSoundOnEndDropItemHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnEndLand(LevelDropArea dropArea) { }

	private void OnFallToPositionFirstLand(LevelDropArea dropArea) { }

	public void SetSoundName(string newSoundName) { }

	public void SetToDestroyAfterFirstFall() { }

	public void StartSound() { }

}

