namespace Game.Level;

public class LevelOrderManu : MonoBehaviour
{
	[SerializeField]
	private LevelScreenManuManager _manager; //Field offset: 0x20
	[SerializeField]
	private LevelButton[] _firstScreenButtons; //Field offset: 0x28
	[SerializeField]
	private LevelButton[] _secondScreenButtons; //Field offset: 0x30
	[SerializeField]
	private ManuItem[] _manuTable; //Field offset: 0x38
	[SerializeField]
	private GameObject[] Screens; //Field offset: 0x40
	[SerializeField]
	private int _currentButtonSelected; //Field offset: 0x48
	[SerializeField]
	private bool _isButtonsStayPressed; //Field offset: 0x4C
	[SerializeField]
	private AnimationCurve _curve; //Field offset: 0x50
	private float SlideDistance; //Field offset: 0x58
	private Int32[] _tweenIDs; //Field offset: 0x60
	private SpriteRenderer[] _firstScreenRenderers; //Field offset: 0x68
	private SpriteRenderer[] _secondScreenRenderers; //Field offset: 0x70
	private int _currentScreen; //Field offset: 0x78
	private int _currentTheme; //Field offset: 0x7C
	private bool _isInit; //Field offset: 0x80

	public LevelOrderManu() { }

	[CompilerGenerated]
	private void <SetTheme>b__21_0() { }

	private void Awake() { }

	private void Init() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public void OnManuItemClick(int index) { }

	public void SetTheme(int theme) { }

	public void SlideScreen(bool isLeft) { }

	private void UpdateSelected(int buttonIndex, int screenIndex) { }

}

