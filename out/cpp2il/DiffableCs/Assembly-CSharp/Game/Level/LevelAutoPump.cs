namespace Game.Level;

public class LevelAutoPump : MonoBehaviour
{
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x28
	[SerializeField]
	protected string _soundName; //Field offset: 0x30

	public LevelAutoPump() { }

	protected override void Awake() { }

	protected override void OnItemEndDropAction(LevelItem levelItem) { }

}

