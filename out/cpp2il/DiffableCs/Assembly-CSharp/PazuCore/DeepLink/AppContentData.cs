namespace PazuCore.DeepLink;

public class AppContentData
{
	internal enum ActionType
	{
		None = 0,
		GoToGameplay = 1,
		FocusOnSelection = 2,
	}

	public ActionType actionType; //Field offset: 0x10
	public Int32[] appContent; //Field offset: 0x18

	public AppContentData() { }

}

