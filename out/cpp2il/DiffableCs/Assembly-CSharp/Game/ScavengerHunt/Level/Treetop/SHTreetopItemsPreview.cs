namespace Game.ScavengerHunt.Level.Treetop;

public class SHTreetopItemsPreview : MonoBehaviour
{
	[SerializeField]
	private SHTreetopPreviewItem[] _items; //Field offset: 0x20
	private SHTreetopManager _manager; //Field offset: 0x28

	public SHTreetopItemsPreview() { }

	public void MarkFoundItems(HashSet<String> prefabGuids) { }

	public void SetManager(SHTreetopManager manager) { }

	public void SyncAppearance() { }

}

