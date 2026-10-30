namespace Game.Store;

public class StoreAvatarPassClaimCurrencyWindow : StoreCurrencyRelatedWindowBase
{
	private static StoreAvatarPassClaimCurrencyWindow _instance; //Field offset: 0x0
	[SerializeField]
	private TextMeshProUGUI _currencyAmountText; //Field offset: 0x30

	public StoreAvatarPassClaimCurrencyWindow() { }

	[CompilerGenerated]
	private void <OnCTAButtonClick>b__11_0() { }

	[CompilerGenerated]
	private void <OnCTAButtonClick>b__11_1() { }

	protected virtual void Awake() { }

	private bool CanOpenInCurrentScene() { }

	private void ClickCTAImplement() { }

	private void Init(Item itemData) { }

	protected virtual void OnActiveSceneChanged(Scene scene1, Scene scene2) { }

	public void OnCTAButtonClick() { }

	protected virtual void OnCurrencyBalanceChangedPostClaim() { }

	protected virtual void OnDestroy() { }

	private static void Show(Item itemData) { }

	public static void ShowIfNeeded(Item itemData) { }

}

