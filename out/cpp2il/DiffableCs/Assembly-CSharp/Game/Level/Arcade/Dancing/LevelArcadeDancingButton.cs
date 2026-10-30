namespace Game.Level.Arcade.Dancing;

public class LevelArcadeDancingButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private static Action<Int32> OnButtonPress; //Field offset: 0x0
	[SerializeField]
	protected SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	protected Sprite _spriteOn; //Field offset: 0x28
	[SerializeField]
	protected Sprite _spriteOff; //Field offset: 0x30
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x38
	[SerializeField]
	protected string _onClickSoundName; //Field offset: 0x40
	[SerializeField]
	private int _buttonIndex; //Field offset: 0x48
	[SerializeField]
	private SkeletonAnimation _screen; //Field offset: 0x50
	private String[] _skinNames; //Field offset: 0x58
	private int _currentIndex; //Field offset: 0x60

	public static event Action<Int32> OnButtonPress
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelArcadeDancingButton() { }

	[CompilerGenerated]
	public static void add_OnButtonPress(Action<Int32> value) { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public static void remove_OnButtonPress(Action<Int32> value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SetPressed(int index) { }

}

