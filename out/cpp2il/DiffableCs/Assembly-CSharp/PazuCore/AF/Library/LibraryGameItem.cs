namespace PazuCore.AF.Library;

[RequireComponent(typeof(LibraryTextureComponent))]
public class LibraryGameItem : ButtonBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public LibraryGameItem <>4__this; //Field offset: 0x10
		public String[] currentContext; //Field offset: 0x18

		public <>c__DisplayClass8_0() { }

		internal void <OnClick>b__0(bool success) { }

	}

	[SerializeField]
	protected GameObject _shadow; //Field offset: 0x20
	protected LibraryGame _game; //Field offset: 0x28
	protected LibraryTextureComponent _item; //Field offset: 0x30
	protected int _sectionId; //Field offset: 0x38
	protected Content _content; //Field offset: 0x40
	private bool _isContent; //Field offset: 0x48
	protected String[] _analyticsContext; //Field offset: 0x50

	public LibraryGameItem() { }

	public override void Init(LibraryGame game, AppearanceType appearanceType, bool isContent, int contentId, int sectionId) { }

	protected virtual void OnClick() { }

}

