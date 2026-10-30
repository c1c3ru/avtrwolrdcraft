namespace PWC.Street;

public class StreetSelectionManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<StreetHouseLayout> <>9__5_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <SetParametersForIpadIfNeeded>b__5_0(StreetHouseLayout houseLayout) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public float alpha; //Field offset: 0x10
		public StreetSelectionManager <>4__this; //Field offset: 0x18
		public bool value; //Field offset: 0x20

		public <>c__DisplayClass6_0() { }

		internal void <SelectionSetActive>b__0(float alphaValue) { }

		internal void <SelectionSetActive>b__1() { }

	}

	[SerializeField]
	private ScrollFocusController _houseLayoutSelection; //Field offset: 0x20
	[SerializeField]
	private CanvasGroup _canvasGroup; //Field offset: 0x28
	[SerializeField]
	private HorizontalLayoutGroup _content; //Field offset: 0x30
	[SerializeField]
	private List<StreetHouseLayout> _houseLayouts; //Field offset: 0x38

	public StreetSelectionManager() { }

	public ScrollPoint GetCenteredHouseLayout() { }

	public void Init() { }

	public void MoveToHouseLayout(ScrollPoint scrollPoint, bool isToRight) { }

	public void SelectionSetActive(bool value) { }

	private void SetParametersForIpadIfNeeded() { }

}

