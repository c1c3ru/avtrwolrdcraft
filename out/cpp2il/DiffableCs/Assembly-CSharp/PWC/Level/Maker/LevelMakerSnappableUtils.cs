namespace PWC.Level.Maker;

public static class LevelMakerSnappableUtils
{
	private class DataItem
	{
		public ILevelMakerSnappableFloorLineObject obj; //Field offset: 0x10
		public int sortingOrder; //Field offset: 0x18
		public Bounds bounds; //Field offset: 0x1C
		public Vector3 boxMin; //Field offset: 0x34
		public Vector3 boxMax; //Field offset: 0x40
		public readonly List<DataItem> intersectingObjects; //Field offset: 0x50
		public bool isFlipped; //Field offset: 0x58
		public bool isYFlipped; //Field offset: 0x59
		public bool useZ; //Field offset: 0x5A

		public DataItem() { }

		public MonoBehaviour GetMonoBehaviour() { }

		public void SyncSortingOrderWithObject() { }

	}

	private class DataItems
	{
		public int count; //Field offset: 0x10
		public DataItem[] array; //Field offset: 0x18

		public DataItems() { }

	}

	private static readonly DataItems _dataItems; //Field offset: 0x0
	private static readonly DataItem _lhsDataItemForObjCompare; //Field offset: 0x8
	private static readonly DataItem _rhsDataItemForObjCompare; //Field offset: 0x10
	private static int tooManycallsLastFrame; //Field offset: 0x18

	private static LevelMakerSnappableUtils() { }

	private static void CalculateSortingForDataItems(DataItems dataItems) { }

	private static int CompareDataItems(DataItem lhs, DataItem rhs) { }

	public static int CompareLineObjects(ILevelMakerSnappableFloorLineObject lhs, ILevelMakerSnappableFloorLineObject rhs, bool isFlipped, bool isYFlipped, bool useZ) { }

	private static void GetIntersections(DataItem item, DataItems candidates) { }

	private static int GetMaxCalls(int frameCount) { }

	private static void InitDataItem(DataItem dataItem, ILevelMakerSnappableFloorLineObject obj, bool isFlipped, bool isYFlipped, bool useZ, Func<ILevelMakerSnappableFloorLineObject, ValueTuple`2<Vector3, Vector3>> overrideMinMax = null) { }

	private static void SetSortingOrderForItems(List<ILevelMakerSnappableFloorLineObject> list, bool isFlipped, bool isYFlipped, bool useZ, Func<ILevelMakerSnappableFloorLineObject, ValueTuple`2<Vector3, Vector3>> overrideMinMax = null) { }

	private static void SortRecursive(DataItem dataItem, ref int callCounter, int frameCount) { }

	public static void SyncSortingOrder(List<ILevelMakerSnappableFloorLineObject> list, bool isFlipped, bool isYFlipped = false, bool useZ = false, Func<ILevelMakerSnappableFloorLineObject, ValueTuple`2<Vector3, Vector3>> overrideMinMax = null) { }

}

