namespace PazuCore.AF.ActionBar;

public class FeedButton : ToggleBase
{
	[SerializeField]
	private GameObject _notif; //Field offset: 0x60

	public FeedButton() { }

	protected virtual void Awake() { }

	private void ChackForUnseenFeedItems() { }

	protected virtual void OnSelected(bool byUserInput) { }

	protected virtual void OnValueChangedOverride(bool value) { }

}

