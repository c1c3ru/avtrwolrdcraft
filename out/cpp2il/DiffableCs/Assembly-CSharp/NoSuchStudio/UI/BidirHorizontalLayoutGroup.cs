namespace NoSuchStudio.UI;

[AddComponentMenu("Layout/Bidirectional Horizontal Layout Group", 153)]
public class BidirHorizontalLayoutGroup : HorizontalOrVerticalLayoutGroup
{
	private static readonly Vector2 TopLeft; //Field offset: 0x0
	private static readonly Vector2 BottomLeft; //Field offset: 0x8
	private static readonly Vector2 TopRight; //Field offset: 0x10
	private static readonly Vector2 BottomRight; //Field offset: 0x18
	[SerializeField]
	protected bool m_IsReverse; //Field offset: 0x6B

	public bool IsReverse
	{
		 get { } //Length: 8
		 set { } //Length: 92
	}

	private static BidirHorizontalLayoutGroup() { }

	protected BidirHorizontalLayoutGroup() { }

	public virtual void CalculateLayoutInputHorizontal() { }

	public virtual void CalculateLayoutInputVertical() { }

	public bool get_IsReverse() { }

	private void GetChildSizes(RectTransform child, int axis, bool controlSize, bool childForceExpand, out float min, out float preferred, out float flexible) { }

	protected float GetStartOffsetWithReverse(int axis, bool isReverse, float requiredSpaceWithoutPadding) { }

	public void set_IsReverse(bool value) { }

	protected void SetChildAlongAxisWithScaleAndDirection(RectTransform rect, int axis, bool reverse, float pos, float size, float scaleFactor) { }

	protected void SetChildAlongAxisWithScaleAndDirection(RectTransform rect, int axis, bool isReverse, float pos, float scaleFactor) { }

	protected void SetChildrenAlongAxisWithReverse(int axis, bool isVertical, bool isReverse) { }

	public virtual void SetLayoutHorizontal() { }

	public virtual void SetLayoutVertical() { }

}

