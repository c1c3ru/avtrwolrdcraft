namespace PWC;

public class MultisizeItemGrid : MonoBehaviour
{
	[CompilerGenerated]
	private struct <>c__DisplayClass3_0
	{
		public Bounds[] boundsArray; //Field offset: 0x0
		public Bounds totalBounds; //Field offset: 0x8
		public RectTransform itemToInsert; //Field offset: 0x20

	}

	[SerializeField]
	private RectTransform _scrollRect; //Field offset: 0x20
	[SerializeField]
	private RectTransform _content; //Field offset: 0x28

	public MultisizeItemGrid() { }

	[CompilerGenerated]
	internal static bool <TryGetPlaceForItem>g__TryInsertItemWithBounds|3_0(Bounds itemToInsertBounds, ref <>c__DisplayClass3_0 unnamed_param_1) { }

	private Bounds GetRectTransformWorldBounds(RectTransform rectTransform, Vector3[] cornersArrayToOverride) { }

	public void RefreshPositions() { }

	private bool TryGetPlaceForItem(RectTransform itemToInsert, List<RectTransform> amongItems) { }

}

