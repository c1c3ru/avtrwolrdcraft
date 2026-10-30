namespace Game.Level;

public class LevelDrinkMachineManager : MonoBehaviour
{
	[SerializeField]
	private LevelDrinkMachineButton[] _buttons; //Field offset: 0x20
	private int _currentPressedButtonIndex; //Field offset: 0x28
	private int _numOfButtons; //Field offset: 0x2C

	public LevelDrinkMachineManager() { }

	protected void Awake() { }

	protected void OnDestroy() { }

	private void OnLevelPostInit() { }

	public void TurnOffMachine() { }

	private void TurnOffPreviusButton() { }

	public void UpdatePressedButtonIndex(int index) { }

}

