namespace Store.Level;

public class StoreContextualPacksBase : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public string productName; //Field offset: 0x10
		public Predicate<Item> <>9__1; //Field offset: 0x18

		public <>c__DisplayClass6_0() { }

		internal void <OnIAPEnded>b__0() { }

		internal bool <OnIAPEnded>b__1(Item x) { }

	}

	protected Item _storePackItemData; //Field offset: 0x20
	private GameObject _window; //Field offset: 0x28
	private GameObject _windowParent; //Field offset: 0x30

	public StoreContextualPacksBase() { }

	protected override void Awake() { }

	protected bool IsWindowOpen() { }

	protected override void OnDestroy() { }

	private void OnIAPEnded(IAPResult result) { }

	public void ShowClaimWindow() { }

	protected override void TryOverrideOnClaimItemSuccess(StoreClaimItemCloudResponse response, ref bool didOverride) { }

}

