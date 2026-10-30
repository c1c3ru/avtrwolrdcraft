namespace PazuCore.AF.Library;

[RequireComponent(typeof(LibraryTextureComponent))]
public class LibraryGameContentItem : LibraryGameItem
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public String[] currentContext; //Field offset: 0x10
		public LibraryGameContentItem <>4__this; //Field offset: 0x18

		public <>c__DisplayClass3_0() { }

		internal void <OnClick>b__0(bool success) { }

	}

	[SerializeField]
	private LibraryTextureComponent _subItem; //Field offset: 0x58
	[SerializeField]
	private GameObject _subItemBg; //Field offset: 0x60

	public LibraryGameContentItem() { }

	public void Init(LibraryGame game, int contentId, int sectionId) { }

	protected virtual void OnClick() { }

}

