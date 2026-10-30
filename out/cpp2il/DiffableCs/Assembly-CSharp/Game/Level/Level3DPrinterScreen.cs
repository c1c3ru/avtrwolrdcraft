namespace Game.Level;

public class Level3DPrinterScreen : MonoBehaviour
{
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer _screenDisplay; //Field offset: 0x28
	[SerializeField]
	private LevelButton _nextButton; //Field offset: 0x30
	[SerializeField]
	private LevelButton _prevButton; //Field offset: 0x38
	[SerializeField]
	private Sprite[] _printablesSprites; //Field offset: 0x40
	private int _currentIndex; //Field offset: 0x48
	private int _numberOfItems; //Field offset: 0x4C

	public Level3DPrinterScreen() { }

	private void Awake() { }

	public int GetCurrentItemOnScreen() { }

	private void OnDestroy() { }

	public void OnNextButtonPressed() { }

	private void OnPostInitAction() { }

	public void OnPrevButtonPressed() { }

	public void ToggleButtonsActivation(bool state) { }

	private void UpdateScreen() { }

}

