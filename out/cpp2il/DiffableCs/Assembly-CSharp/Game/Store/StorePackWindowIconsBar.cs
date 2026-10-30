namespace Game.Store;

public class StorePackWindowIconsBar : MonoBehaviour
{
	[SerializeField]
	private StorePackWindowIcon _iconPrefab; //Field offset: 0x20
	[SerializeField]
	private Transform[] _iconAnchors; //Field offset: 0x28

	public int MaxIconsCount
	{
		 get { } //Length: 24
	}

	public StorePackWindowIconsBar() { }

	public void AddIcon(Sprite sprite, int amount, string iconName, string nameKey, int anchorIndex) { }

	public void ClearIcons() { }

	public int get_MaxIconsCount() { }

	private bool TryGetAnchor(int anchorIndex, out Transform anchor) { }

}

