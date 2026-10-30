namespace Game.Level;

public class LevelMidiController : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private static Action<Boolean> OnMidiControllerSetActiveAction; //Field offset: 0x0
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	private Sprite _onState; //Field offset: 0x28
	[SerializeField]
	private Sprite _offState; //Field offset: 0x30
	[SerializeField]
	private LevelMidiControllerSpeaker _speaker; //Field offset: 0x38
	[SerializeField]
	private LevelMidiControllerButton[] _buttons; //Field offset: 0x40
	private int _clickedButtonPosition; //Field offset: 0x48

	public static event Action<Boolean> OnMidiControllerSetActiveAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelMidiController() { }

	[CompilerGenerated]
	public static void add_OnMidiControllerSetActiveAction(Action<Boolean> value) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public void OnButtonClick(LevelMidiControllerButton clickedButton) { }

	[CompilerGenerated]
	public static void remove_OnMidiControllerSetActiveAction(Action<Boolean> value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

