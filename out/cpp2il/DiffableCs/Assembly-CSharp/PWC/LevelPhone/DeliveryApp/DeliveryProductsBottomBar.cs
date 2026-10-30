namespace PWC.LevelPhone.DeliveryApp;

public class DeliveryProductsBottomBar : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _totalAmountText; //Field offset: 0x20
	private int _totalAmount; //Field offset: 0x28

	public DeliveryProductsBottomBar() { }

	private void Awake() { }

	public void OnBackButtonClick() { }

	private void OnDestroy() { }

	private void SetTotalAmount() { }

	public void UpdateView(int totalAmount) { }

}

