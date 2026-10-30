namespace Game.Store;

public abstract class StoreCurrencyRelatedWindowBase : Window
{

	protected StoreCurrencyRelatedWindowBase() { }

	protected override void Awake() { }

	protected void HideWindow() { }

	protected override void OnActiveSceneChanged(Scene scene1, Scene scene2) { }

	public void OnCloseButtonClick() { }

	protected override void OnCurrencyBalanceChangedPostClaim() { }

	protected virtual void OnDestroy() { }

	protected static T ShowGeneric() { }

}

