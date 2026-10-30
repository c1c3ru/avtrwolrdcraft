namespace PazuCore.AF.Library.LibraryAnalytics;

public class LibraryEventDataGamePage : LibraryEventData
{
	internal enum SourceType
	{
		Section = 0,
		FeaturedGame = 1,
	}

	public int targetGameId; //Field offset: 0x3C
	public bool isInstall; //Field offset: 0x40
	public int sectionId; //Field offset: 0x44
	public int gameScrollPosition; //Field offset: 0x48
	public int sectionScrollPosition; //Field offset: 0x4C
	public AppearanceType appearanceType; //Field offset: 0x50
	public SourceType sourceType; //Field offset: 0x54

	public LibraryEventDataGamePage() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

