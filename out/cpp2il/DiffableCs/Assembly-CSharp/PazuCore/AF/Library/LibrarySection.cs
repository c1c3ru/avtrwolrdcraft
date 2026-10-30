namespace PazuCore.AF.Library;

public class LibrarySection
{
	internal class Content
	{
		public int id; //Field offset: 0x10
		public int gameId; //Field offset: 0x14

		public Content() { }

	}

	internal enum Type
	{
		None = 0,
		Top10 = 1,
		New = 2,
		RelatedGames = 3,
		Content = 4,
	}

	[SerializeField]
	private string template; //Field offset: 0x10
	[SerializeField]
	private string type; //Field offset: 0x18
	[SerializeField]
	private List<String> sortBy; //Field offset: 0x20
	public int id; //Field offset: 0x28
	public string titleTextKey; //Field offset: 0x30
	public string iconUrl; //Field offset: 0x38
	public string headerUrl; //Field offset: 0x40
	public string headerTileUrl; //Field offset: 0x48
	public string footerUrl; //Field offset: 0x50
	public string footerTileUrl; //Field offset: 0x58
	public string addressableCustomName; //Field offset: 0x60
	public List<Int32> games; //Field offset: 0x68
	public List<Content> content; //Field offset: 0x70
	private Nullable<AppearanceType> _gamesAppearanceType; //Field offset: 0x78
	private Nullable<Type> _type; //Field offset: 0x80
	private List<SortType> _sortTypes; //Field offset: 0x88
	private HashSet<Int32> _hashSetGames; //Field offset: 0x90

	public LibrarySection() { }

	public bool ContainsGame(int gameId) { }

	public AppearanceType GetGamesAppearanceType() { }

	public Type GetSectionType() { }

	public List<SortType> GetSortTypes() { }

}

