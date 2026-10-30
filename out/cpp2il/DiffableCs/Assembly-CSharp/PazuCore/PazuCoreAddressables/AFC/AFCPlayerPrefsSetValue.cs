namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCPlayerPrefsSetValue : MonoBehaviour
{
	[SerializeField]
	private string _playerPrefsKey; //Field offset: 0x20

	public AFCPlayerPrefsSetValue() { }

	public void DecrementInt() { }

	public void DeleteKey() { }

	public void IncrementInt() { }

	private bool IsKeyValid() { }

	public void SetInt(int value) { }

	public void SetString(string value) { }

}

