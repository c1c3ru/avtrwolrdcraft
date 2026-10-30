namespace PazuCore;

[RequireComponent(typeof(HorizontalOrVerticalLayoutGroup))]
public class LayoutGroupSpacingToScreenPortrait : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public LayoutGroupSpacingToScreenPortrait <>4__this; //Field offset: 0x10
		public HorizontalOrVerticalLayoutGroup layoutGroup; //Field offset: 0x18

		public <>c__DisplayClass7_0() { }

		internal void <Editor_SaveValuesForCurrentScreen>b__0() { }

	}

	[SerializeField]
	private float _spacingPortrait; //Field offset: 0x20
	[SerializeField]
	private float _spacingTall; //Field offset: 0x24
	[SerializeField]
	private float _spacingVeryTall; //Field offset: 0x28
	private HorizontalOrVerticalLayoutGroup _layoutGroup; //Field offset: 0x30

	public LayoutGroupSpacingToScreenPortrait() { }

	private void ApplyValuesForCurrentScreen() { }

	[ContextMenu("Apply Values For Current Screen")]
	private void Editor_ApplyValuesForCurrentScreen() { }

	[ContextMenu("Save Values For Current Screen")]
	private void Editor_SaveValuesForCurrentScreen() { }

	private void SetSpacing(float spacing) { }

	private void Start() { }

}

