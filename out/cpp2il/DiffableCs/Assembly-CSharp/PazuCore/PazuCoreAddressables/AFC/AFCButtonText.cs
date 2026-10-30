namespace PazuCore.PazuCoreAddressables.AFC;

[RequireComponent(typeof(Text))]
public class AFCButtonText : MonoBehaviour
{
	[SerializeField]
	private Color _staticColor; //Field offset: 0x20
	[SerializeField]
	private Color _pressedColor; //Field offset: 0x30
	private Text _text; //Field offset: 0x40
	private AddressablesButton _button; //Field offset: 0x48

	public AFCButtonText() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnPointerDown() { }

	private void OnPointerUp() { }

}

