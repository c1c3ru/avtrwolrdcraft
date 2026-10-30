namespace Game.Store;

public class StoreAvatarIDRequriedWindow : StoreCurrencyRelatedWindowBase
{
	private Action _onCTAClickAction; //Field offset: 0x30

	public StoreAvatarIDRequriedWindow() { }

	private void Init(Action onCTAClickAction) { }

	protected virtual void OnActiveSceneChanged(Scene scene1, Scene scene2) { }

	public void OnCTAButtonClick() { }

	protected virtual void OnCurrencyBalanceChangedPostClaim() { }

	public static void Show(Action onCTAClickAction) { }

}

