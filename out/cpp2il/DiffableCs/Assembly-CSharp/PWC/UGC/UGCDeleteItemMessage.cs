namespace PWC.UGC;

public class UGCDeleteItemMessage : MonoBehaviour
{
	[SerializeField]
	private GameObject _view; //Field offset: 0x20
	[SerializeField]
	private Text _messageText; //Field offset: 0x28
	private Action _onCTAClick; //Field offset: 0x30

	public UGCDeleteItemMessage() { }

	private void Awake() { }

	public void Hide() { }

	public void OnCloseButtonClick() { }

	public void OnCTAButtonClick() { }

	public void Show(string messageText, Action onCTAClick) { }

}

