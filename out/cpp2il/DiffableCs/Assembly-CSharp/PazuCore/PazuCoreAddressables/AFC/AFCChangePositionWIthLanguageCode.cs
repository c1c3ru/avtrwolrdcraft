namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCChangePositionWIthLanguageCode : MonoBehaviour
{
	[SerializeField]
	private SerializableDictionaryBase<String, Vector2> _languageCodeToPosition; //Field offset: 0x20

	public AFCChangePositionWIthLanguageCode() { }

	public void SetPosition(string languageCode) { }

}

