namespace PazuCore.PazuCoreAddressables.AFC;

[RequireComponent(typeof(TMP_Text))]
public class AFCTMPTextLineSpaceWIthLanguageCode : MonoBehaviour
{
	[SerializeField]
	private SerializableDictionaryBase<String, Single> _languageCodeToLineSpace; //Field offset: 0x20

	public AFCTMPTextLineSpaceWIthLanguageCode() { }

	public void SetLineSpacing(string languageCode) { }

}

