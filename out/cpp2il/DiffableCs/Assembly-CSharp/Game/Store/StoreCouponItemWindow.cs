namespace Game.Store;

public class StoreCouponItemWindow : MonoBehaviour
{
	[SerializeField]
	private InputField _inputField; //Field offset: 0x20
	[SerializeField]
	private Button _redeemButton; //Field offset: 0x28

	public StoreCouponItemWindow() { }

	private void Awake() { }

	public void OnClaimItemButtonClick() { }

	private void OnInputFieldValueChange(string value) { }

}

