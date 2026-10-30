namespace PWC.Multiplayer.WorldScene;

public class WorldMPUIJoinCodeViewer : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private GameObject _joinCodeViewer; //Field offset: 0x20
	[SerializeField]
	private Text _joinCodeText; //Field offset: 0x28
	private bool _isOpen; //Field offset: 0x30

	public WorldMPUIJoinCodeViewer() { }

	private void Awake() { }

	private void SetIsOpen(bool isOpen, bool useTween, bool force = false) { }

	private override void UnityEngine.EventSystems.IPointerClickHandler.OnPointerClick(PointerEventData eventData) { }

}

