namespace PazuCore.AF.Library;

public abstract class LibraryStructureBase
{
	public LibraryType libraryType; //Field offset: 0x10
	public List<LibrarySection> sections; //Field offset: 0x18
	private Dictionary<Int32, HashSet`1<Type>> _gamesSectionTypes; //Field offset: 0x20

	protected LibraryStructureBase() { }

	public HashSet<Type> GetGameSectionTypes(int gameId) { }

}

