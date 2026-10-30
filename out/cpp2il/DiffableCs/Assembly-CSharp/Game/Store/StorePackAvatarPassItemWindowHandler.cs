namespace Game.Store;

public class StorePackAvatarPassItemWindowHandler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	private static StorePackAvatarPassItemWindowHandler _current; //Field offset: 0x0
	private StorePackItemWindow _packItemWindow; //Field offset: 0x20

	public static StorePackAvatarPassItemWindowHandler Current
	{
		 get { } //Length: 72
	}

	public StorePackAvatarPassItemWindowHandler() { }

	private void Awake() { }

	public static StorePackAvatarPassItemWindowHandler get_Current() { }

	private void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public StorePackItemBase ReturnToItem() { }

	private bool TryOverrideClickClaim(StorePackItemWindow _) { }

}

