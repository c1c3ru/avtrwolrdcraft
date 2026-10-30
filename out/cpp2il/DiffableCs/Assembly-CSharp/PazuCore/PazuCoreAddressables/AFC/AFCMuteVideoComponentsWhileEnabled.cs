namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCMuteVideoComponentsWhileEnabled : MonoBehaviour
{
	[SerializeField]
	private VideoComponent _exclude; //Field offset: 0x20
	private readonly List<VideoComponent> _mutedVideoComponents; //Field offset: 0x28
	private readonly List<LibraryVideoComponent> _mutedLibraryVideoComponents; //Field offset: 0x30

	public AFCMuteVideoComponentsWhileEnabled() { }

	private void OnDisable() { }

	private void OnEnable() { }

}

