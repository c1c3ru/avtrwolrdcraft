namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCBreadCrumbHandler : MonoBehaviour
{
	public static readonly List<String> Path; //Field offset: 0x0
	[SerializeField]
	private string _key; //Field offset: 0x20

	private static AFCBreadCrumbHandler() { }

	public AFCBreadCrumbHandler() { }

	private void OnDisable() { }

	private void OnEnable() { }

}

