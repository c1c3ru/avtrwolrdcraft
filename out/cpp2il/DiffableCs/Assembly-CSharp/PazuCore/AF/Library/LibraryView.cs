namespace PazuCore.AF.Library;

public class LibraryView : AddressablesFeatureViewBase
{
	[SerializeField]
	private string _analyticsContextId; //Field offset: 0x48

	public string AnalyticsContextId
	{
		 get { } //Length: 8
	}

	public LibraryView() { }

	protected virtual void Awake() { }

	public string get_AnalyticsContextId() { }

}

