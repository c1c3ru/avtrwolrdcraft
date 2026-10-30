namespace Game.Store;

public class StoreCurrencyPackProposalWindow : StoreCurrencyRelatedWindowBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public string starterCurrencyPackName; //Field offset: 0x10

		public <>c__DisplayClass5_0() { }

		internal bool <Init>b__1(Item x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_1
	{
		public int index; //Field offset: 0x10
		public Predicate<Int32> <>9__3; //Field offset: 0x18

		public <>c__DisplayClass5_1() { }

		internal bool <Init>b__2(ItemsLayoutGroup layoutItem) { }

		internal bool <Init>b__3(int itemIndex) { }

	}

	[SerializeField]
	private TextMeshProUGUI _Text; //Field offset: 0x30
	[SerializeField]
	private Transform _packParent; //Field offset: 0x38
	[SerializeField]
	private Transform _CTAButton; //Field offset: 0x40
	[SerializeField]
	private Transform _allCoins; //Field offset: 0x48

	public StoreCurrencyPackProposalWindow() { }

	[CompilerGenerated]
	internal static bool <Init>g__IsIndexExistsInGroup|5_0(Group group, int index) { }

	private void Init(Item itemData) { }

	public void OnCTAButtonClick() { }

	public static void Show(Item itemData) { }

}

