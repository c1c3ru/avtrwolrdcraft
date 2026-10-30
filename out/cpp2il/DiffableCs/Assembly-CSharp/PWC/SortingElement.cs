namespace PWC;

public class SortingElement : MonoBehaviour
{
	private long _sortingOrder; //Field offset: 0x20
	private bool _isDirty; //Field offset: 0x28
	private readonly List<SortingGroup> _sortingGrousplistForSorting; //Field offset: 0x30
	private TransformChangedHandler _transformChangedHandler; //Field offset: 0x38

	public SortingElement() { }

	private void Awake() { }

	public long GetSortingOrderForY() { }

	private void OnDestroy() { }

	public void SetDirty() { }

}

