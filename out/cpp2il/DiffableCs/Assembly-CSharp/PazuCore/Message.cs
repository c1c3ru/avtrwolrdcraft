namespace PazuCore;

public class Message : Window
{
	[SerializeField]
	private Text title; //Field offset: 0x30
	[SerializeField]
	private Text text; //Field offset: 0x38
	[SerializeField]
	private Text buttonText; //Field offset: 0x40
	[SerializeField]
	private GameObject _closeButton; //Field offset: 0x48
	private Action _onCtaClick; //Field offset: 0x50
	private Action _onCloseClick; //Field offset: 0x58

	public Message() { }

	public virtual void CloseWindow() { }

	public Button GetCTAButton() { }

	public void OnCloseButtonClick() { }

	public void OnCTAButtonClick() { }

	public void SetMessage(string title, string text, string buttonText, Action onCtaClick, bool showCloseButton, Action onCloseClick) { }

}

