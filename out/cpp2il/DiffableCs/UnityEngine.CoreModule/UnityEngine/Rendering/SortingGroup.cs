namespace UnityEngine.Rendering;

[NativeType(Header = "Runtime/2D/Sorting/SortingGroup.h")]
[RequireComponent(typeof(Transform))]
public sealed class SortingGroup : Behaviour
{

	[StaticAccessor("SortingGroup", StaticAccessorType::DoubleColon (2))]
	internal static int invalidSortingGroupID
	{
		internal get { } //Length: 40
	}

	public bool sortAtRoot
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public int sortingLayerID
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public string sortingLayerName
	{
		 set { } //Length: 68
	}

	public int sortingOrder
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public SortingGroup() { }

	internal static int get_invalidSortingGroupID() { }

	public bool get_sortAtRoot() { }

	public int get_sortingLayerID() { }

	public int get_sortingOrder() { }

	[StaticAccessor("SortingGroup", StaticAccessorType::DoubleColon (2))]
	internal static SortingGroup GetSortingGroupByIndex(int index) { }

	public void set_sortAtRoot(bool value) { }

	public void set_sortingLayerID(int value) { }

	public void set_sortingLayerName(string value) { }

	public void set_sortingOrder(int value) { }

}

