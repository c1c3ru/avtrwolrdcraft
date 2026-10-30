namespace PazuCore.AF.Library.LibraryAnalytics;

public class LibraryEventData : EventDataBase
{
	public LibraryEventType libraryEventType; //Field offset: 0x38

	public LibraryEventData() { }

	public virtual Dictionary<String, Object> GetRequestObject() { }

}

