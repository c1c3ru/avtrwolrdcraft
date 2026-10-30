namespace PWC.UGC;

public class UGCPreventDeletionItemHandler : MonoBehaviour
{
	private UGCItemBase _ugcItem; //Field offset: 0x20

	public UGCPreventDeletionItemHandler() { }

	private void Awake() { }

	public void CanBeDeleted(ref bool canBeDeleted) { }

	private void OnDestroy() { }

}

