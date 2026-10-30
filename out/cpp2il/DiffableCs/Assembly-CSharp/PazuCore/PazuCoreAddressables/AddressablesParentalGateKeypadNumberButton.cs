namespace PazuCore.PazuCoreAddressables;

public class AddressablesParentalGateKeypadNumberButton : AddressablesButton
{
	[CompilerGenerated]
	private static Action<Int32> OnKeypadNumberButtonClickAction; //Field offset: 0x0
	[Range(0, 9)]
	[SerializeField]
	private int _number; //Field offset: 0x50

	public static event Action<Int32> OnKeypadNumberButtonClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public AddressablesParentalGateKeypadNumberButton() { }

	[CompilerGenerated]
	public static void add_OnKeypadNumberButtonClickAction(Action<Int32> value) { }

	protected virtual void OnPointerClickInternal() { }

	[CompilerGenerated]
	public static void remove_OnKeypadNumberButtonClickAction(Action<Int32> value) { }

}

