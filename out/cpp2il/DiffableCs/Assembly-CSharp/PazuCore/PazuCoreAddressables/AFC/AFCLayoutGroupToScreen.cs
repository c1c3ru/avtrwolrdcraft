namespace PazuCore.PazuCoreAddressables.AFC;

[RequireComponent(typeof(LayoutGroup))]
public class AFCLayoutGroupToScreen : AFCScreenHandlerBase
{
	[FormerlySerializedAs("_topPortrait")]
	[Header("Top")]
	[SerializeField]
	private int _topTablet; //Field offset: 0x24
	[FormerlySerializedAs("_topTall")]
	[SerializeField]
	private int _topLong; //Field offset: 0x28
	[FormerlySerializedAs("_topVeryTall")]
	[SerializeField]
	private int _topVeryLong; //Field offset: 0x2C
	[FormerlySerializedAs("_bottomPortrait")]
	[Header("Bottom")]
	[SerializeField]
	private int _bottomTablet; //Field offset: 0x30
	[FormerlySerializedAs("_bottomTall")]
	[SerializeField]
	private int _bottomLong; //Field offset: 0x34
	[FormerlySerializedAs("_bottomVeryTall")]
	[SerializeField]
	private int _bottomVeryLong; //Field offset: 0x38
	private LayoutGroup _layoutGroup; //Field offset: 0x40

	public AFCLayoutGroupToScreen() { }

	protected virtual void Awake() { }

	protected virtual void HandleLong() { }

	protected virtual void HandleTablet() { }

	protected virtual void HandleVeryLong() { }

	private void SetBottom(int bottom) { }

	private void SetTop(int top) { }

}

