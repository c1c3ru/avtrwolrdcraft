namespace PazuCore.PazuCoreAddressables;

public class AddressablesParentalGateKeypad : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<Text> <>9__7_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <ResetKeypad>b__7_0(Text line) { }

	}

	[SerializeField]
	private UnityEvent _onDateValidEvent; //Field offset: 0x20
	[SerializeField]
	private List<Text> _lines; //Field offset: 0x28
	private int _currentLineIndex; //Field offset: 0x30

	public AddressablesParentalGateKeypad() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnKeypadDeleteButtonClick() { }

	private void OnKeypadNumberButtonClick(int number) { }

	private void OnKeypadNumbersFull() { }

	private void ResetKeypad(bool animateShake) { }

}

