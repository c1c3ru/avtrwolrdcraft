namespace Game.Level;

public class LevelBurgerMachineCashRegister : MonoBehaviour
{
	[SerializeField]
	private TextMesh _textMesh; //Field offset: 0x20
	[SerializeField]
	private LevelBleepOnEnterElement _cardReader; //Field offset: 0x28
	private int _currentAmount; //Field offset: 0x30

	public LevelBurgerMachineCashRegister() { }

	public void AddToSum(int amount) { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnPay(LevelDragActionByTagItemHandler item) { }

}

